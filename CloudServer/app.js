var express = require("express");
var app = express();
var bodyParser = require("body-parser");
var cookieParser = require("cookie-parser");
var config = require("./config/db.js");
//var config = require("./config/db_local.js");
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
var mysql = require("mysql");
var session = require("express-session");
const { request } = require("express");
//const { password } = require("./config/db.js");
app.use(
  session({
    secret: "123456789",
    resave: false,
    saveUninitialized: true,
  })
);

var connection = mysql.createConnection({
  host: config.host,
  user: config.user,
  password: config.password,
  database: config.database,
});

connection.connect(function (err) {
  if (err) {
    console.log(err);
  } else {
    console.log("Veritabanı bağlantısı başarılı");
  }
});

function checkSignIn(req, res, next) {
  if (req.session.User_ID) {
    // console.log(req.session.User_ID);
    next();
  } else {
    var err = new Error("Not logged in!");

    next(err);
  }
}

app.get("/logincheck", function (req, res) {
  if (req.session.User_ID) {
    res.json({ status: "logged_in" });
    res.end();
  } else {
    res.json({ status: "not_logged_in" });
    res.end();
  }
});
app.get("/logout", function (req, res) {
  req.session.destroy();
  res.json({ message: "logged_out" });
});
app.get("/userid", function (req, res) {
  try {
    console.log(req.session.User_ID);
    res.json({ User_ID: req.session.User_ID });
    res.end();
  } catch (error) {
    console.log(error);
    res.end();
  }
});
app.get("/userinfo", checkSignIn, function (req, res) {
  try {
    let sql =
      "SELECT * FROM users WHERE User_ID = " +
      mysql.escape(req.session.User_ID);

    connection.query(sql, function (err, results) {
      if (err) throw err;
      res.json(results[0]);
      res.end();
    });
  } catch (error) {
    console.log(error);
    res.end();
  }
});
app.use("/userinfo", function (err, req, res, next) {
  res.json({ status: "not_logged_in" });
  res.end();
});

app.post("/girisyap", function (req, res) {
  var status = { status: "none" };
  let sql =
    "SELECT * FROM users WHERE User_Name =" +
    mysql.escape(req.body.username) +
    " and Password=" +
    mysql.escape(req.body.password);

  connection.query(sql, function (err, results) {
    if (err) throw err;
    if (results.length == 1) {
      status.status = "logged_in";
      req.session.User_ID = results[0].User_ID;

      res.json(status);
      //  res.end();
    } else {
      status.status = "invalid";
      res.json(status);
      // res.end();
    }
  });
});
app.post("/kayitol", function (req, res) {
  if (req.body.email && req.body.username && req.body.password) {
    var sql =
      "INSERT INTO users(User_Name,E_Mail,Password) VALUES(" +
      mysql.escape(req.body.username) +
      "," +
      mysql.escape(req.body.email) +
      "," +
      mysql.escape(req.body.password) +
      ")";
    connection.query(sql, function (err, result) {
      if (err) throw err;
      res.json({ status: "success" });
      res.end();
    });
  } else {
    res.json({ status: "error" });
    res.end();
  }
});

app.post("/sifredegistir", function (req, res) {
  var old_password;
  if (req.body.yenisifre) {
    try {
      let sql0 =
        "SELECT * FROM users WHERE User_Name = " +
        mysql.escape(req.body.username);

      connection.query(sql0, function (err, results) {
        if (err) throw err;
        old_password = results[0].Password;
        if (old_password == req.body.eskisifre) {
          var sql =
            "UPDATE users SET Password=" +
            mysql.escape(req.body.yenisifre) +
            " WHERE User_Name=" +
            mysql.escape(req.body.username);
          connection.query(sql, function (err, result) {
            if (err) console.log("error");
            res.json({ status: "success" });
            res.end();
          });
        } else {
          res.json({ status: "error" });
          res.end();
        }
      });
    } catch (error) {
      res.send("hata");
      res.end();
    }
  } else {
    res.json({ status: "error" });
    res.end();
  }
});
app.use("/sifredegistir", function (err, req, res, next) {
  res.json({ status: "not_logged_in" });
  res.end();
});
app.post("/kargoekle", checkSignIn, function (req, res) {
  if (req.body.CustomerName) {
    var CustomerName = req.body.CustomerName;
    var CustomerLocationLatitude = req.body.CustomerLocationLatitude;
    var CustomerLocationLongitude = req.body.CustomerLocationLongitude;
    var DeliveryInformation = req.body.DeliveryInformation;
    var CargoLocationLatitude = req.body.CargoLocationLatitude;
    var CargoLocationLongitude = req.body.CargoLocationLongitude;
    var customerInsertId;

    sql1 =
      "INSERT INTO customer(CustomerName,CustomerLocationLatitude,CustomerLocationLongitude) VALUES (" +
      mysql.escape(CustomerName) +
      "," +
      mysql.escape(CustomerLocationLatitude) +
      "," +
      mysql.escape(CustomerLocationLongitude) +
      ")";
    console.log(sql1);
    connection.query(sql1, function (err, result) {
      if (err) throw err;
      customerInsertId = result.insertId;
      sql2 =
        "INSERT INTO cargo(CargoLocationLatitude,CargoLocationLongitude,CustomerID,DeliveryInformation) VALUES (" +
        mysql.escape(CargoLocationLatitude) +
        "," +
        mysql.escape(CargoLocationLongitude) +
        "," +
        mysql.escape(customerInsertId) +
        "," +
        mysql.escape(DeliveryInformation) +
        ")";
      console.log(sql2);
      connection.query(sql2, function (err, result) {
        if (err) throw err;
        res.json({ status: "success" });
        res.end();
      });
    });
  } else {
    res.json({ status: "error" });
    res.end();
  }
});
// app.use('/kargoekle', function(err, req, res, next){

//   res.send(err);
//   res.end();
// });
app.post("/kargosil", checkSignIn, function (req, res) {
  if (req.body.CargoID) {
    var deleteCustomerID;
    connection.query(
      "SELECT * FROM cargo WHERE CargoID=" + mysql.escape(req.body.CargoID),
      function (err, result, fields) {
        if (err) throw err;
        deleteCustomerID = result[0].CustomerID;
        connection.query(
          "DELETE FROM cargo WHERE CargoID=" + mysql.escape(req.body.CargoID),
          function (err, result, fields) {
            if (err) throw err;

            connection.query(
              "DELETE  FROM customer WHERE CustomerID=" +
                mysql.escape(deleteCustomerID),
              function (err, result, fields) {
                if (err) throw err;

                res.json({ status: "success" });
                res.end();
              }
            );
          }
        );
      }
    );
  } else {
    res.json({ status: "error" });
    res.end();
  }
});
// app.use('/kargosil', function(err, req, res, next){

//   res.json({"status":"not_logged_in"});
//   res.end();
// });
app.post("/kargoguncelle", checkSignIn, function (req, res) {
  if (req.body.CargoID) {
    var CargoID = req.body.CargoID;
    var CustomerName = req.body.CustomerName;
    var CustomerLocationLatitude = req.body.CustomerLocationLatitude;
    var CustomerLocationLongitude = req.body.CustomerLocationLongitude;
    var DeliveryInformation = req.body.DeliveryInformation;
    var CargoLocationLatitude = req.body.CargoLocationLatitude;
    var CargoLocationLongitude = req.body.CargoLocationLongitude;
    var updateCustomerID;
    connection.query(
      "SELECT * FROM cargo WHERE CargoID=" + mysql.escape(req.body.CargoID),
      function (err, result, fields) {
        if (err) throw err;
        updateCustomerID = result[0].CustomerID;
        var update_sql =
          "UPDATE cargo SET  CargoLocationLatitude=" +
          mysql.escape(CargoLocationLatitude) +
          " , CargoLocationLongitude=" +
          mysql.escape(CargoLocationLongitude) +
          " , DeliveryInformation=" +
          mysql.escape(DeliveryInformation) +
          " WHERE CargoID=" +
          mysql.escape(CargoID);
        connection.query(update_sql, function (err, result) {
          if (err) throw err;
          var update_sql2 =
            "UPDATE customer SET CustomerName=" +
            mysql.escape(CustomerName) +
            ", CustomerLocationLatitude=" +
            mysql.escape(CustomerLocationLatitude) +
            ", CustomerLocationLongitude=" +
            mysql.escape(CustomerLocationLongitude) +
            " WHERE CustomerID=" +
            mysql.escape(updateCustomerID);
          connection.query(update_sql2, function (err, result) {
            if (err) throw err;
            res.json({ status: "success" });
            res.end();
          });
        });
      }
    );
  } else {
    res.json({ status: "error" });
    res.end();
  }
});
// app.use('/kargoguncelle', function(err, req, res, next){

//   res.json({"status":"not_logged_in"});
//   res.end();
// });
app.get("/kargolistele", checkSignIn, function (req, res) {
  connection.query("SELECT * FROM cargo", function (err, result) {
    res.json(result);
    res.end();
  });
});
app.post("/customerdetay", function (req, res) {
  if (req.body.CustomerID) {
    connection.query(
      "SELECT * FROM customer WHERE CustomerID=" +
        mysql.escape(req.body.CustomerID),
      function (err, result) {
        if (err) throw err;
        res.json(result[0]);
        res.end();
      }
    );
  } else {
    res.json({ status: "error" });
    res.end();
  }
});
// app.use('/kargolistele', function(err, req, res, next){

//   res.json({"status":"not_logged_in"});
//   res.end();
// });
app.post("/teslimdurumudegistir", checkSignIn, function (req, res) {
  if (req.body.CargoID) {
    try {
      var sql =
        "UPDATE cargo SET DeliveryInformation=" +
        mysql.escape(req.body.DeliveryInformation) +
        " WHERE CargoID=" +
        mysql.escape(req.body.CargoID);
      connection.query(sql, function (err, result) {
        if (err) console.log("error");
        res.json({ status: "success" });
        res.end();
      });
    } catch (error) {
      res.send("hata");
      res.end();
    }
  } else {
    res.json({ status: "error" });
    res.end();
  }
});
// app.use('/teslimdurumudegistir', function(err, req, res, next){

//   res.json({"status":"not_logged_in"});
//   res.end();
// });
app.post("/kullanicikonumudegistir", function (req, res) {
  if (req.body.UserLocationLatitude) {
  var sql="UPDATE users SET UserLocationLatitude="+mysql.escape(req.body.UserLocationLatitude)+", UserLocationLongitude="+mysql.escape(req.body.UserLocationLongitude)+" WHERE User_ID="+mysql.escape(req.session.User_ID);
  connection.query(sql,function(err,results){
    if (err) throw err;
    console.log(sql);
    res.json({status:"success"});
    res.end();

  });

  } else {
    res.json({ status: "error" });
    res.end();
  }
});
app.listen(3000);

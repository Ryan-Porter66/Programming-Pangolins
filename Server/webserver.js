const express = require('express');
var mysql = require('mysql');
require('dotenv').config();

const app = express();

// Parse URL-encoded bodies (as sent by HTML forms)
app.use(express.urlencoded({ extended: true }));

// Parse JSON bodies (as sent by API clients)
app.use(express.json());

app.post('/auth', async function (request, response) {
    // Capture the input fields
    let username = request.body.username;
    let password = request.body.password;
    // Ensure the input fields exists and are not empty
    if (username && password) {

        let user = process.env.USR;
        let pwd = process.env.PASSWORD;
        let db = process.env.DATABASE;
        let server = process.env.SERVER;


        const config = {
            user: user,
            password: pwd,
            host: server,
            database: db
        };

        const statement = "SELECT * FROM employees WHERE emp_id = ?;";

        var con = mysql.createConnection(config);
        var privilege = 'Error';
        con.connect(function (err) {
            if (err) console.log(err);
            console.log("Connected!");
            con.query(statement, username, function (err, result) {
                if (err) {
                    console.log(err);
                    response.send(privilege);
                    response.end();
                }
                if (password === result[0].password_hash)
                    privilege = result[0].permission_level;
                else
                    privelege = 'Denied';
                response.send(privilege);
                response.end();

            });
        });

    } else {
        response.send('Please enter Username and Password!');
        response.end();
    }
});

let port = 5000;
//let port = process.env.PORT;
if (port == null || port == "") {
    port = 5000;
}
app.listen(port, () => {
    console.log(`Listening on port ${port}`);
});
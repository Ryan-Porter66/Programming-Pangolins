const e = require('express');
const express = require('express');
var mysql = require('mysql');
require('dotenv').config();

const app = express();

// Parse URL-encoded bodies (as sent by HTML forms)
app.use(express.urlencoded({ extended: true }));

// Parse JSON bodies (as sent by API clients)
app.use(express.json());

async function dbconnect(u, p) {
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

    const statement = "INSERT INTO test VALUES('" + u + "', '" + p + "');";

    var con = mysql.createConnection(config);

    con.connect(function (err) {
        if (err) console.log(err);
        console.log("Connected!");
        con.query(statement, function (err, result) {
            if (err) console.log(err);
            console.log("Result: " + result);
        });
    });


}

async function login(u, p) {
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
    var privelege = 'Error';
    var temp = await con.connect(async function (err) {
        if (err) console.log(err);
        console.log("Connected!");
        return await con.query(statement, u, function (err, result) {
            if (err) console.log(err);
            console.log("Result: " + result[0].password_hash);
            if (p === result[0].password_hash)
                privelege = result[0].permission_level;
            else
                privelege = 'Denied';  
            return privelege;
        });
    });
    return privelege;
}

app.post('/delemp', async function (request, response) {
    // Capture the input fields
    let username = request.body.username;
    let password = request.body.password;
    let empid = request.body.empid;
    // Ensure the input fields exists and are not empty
    if (username && password) {

        let user = process.env.USR;
        let pwd = process.env.PASSWORD;
        let db = process.env.DATABASE;
        let server = process.env.SERVER;


        const config = {
            connectionLimit: 25,
            user: user,
            password: pwd,
            host: server,
            database: db
        };

        const statement = "update employees e set e.delete_indicator = 1 where e.emp_id = ?;";

        var pool = mysql.createPool(config);
        var resp = 'Error';
        pool.query(statement, empid, function (err, result) {
            if (err) {
                console.log(err);
                response.send(resp);
                response.end();
            }
            response.json(result);
            response.end();

        });

    } else {
        response.send('Please enter Username and Password!');
        response.end();
    }
});

app.post('/updateemp', async function (request, response) {
    // Capture the input fields
    let username = request.body.username;
    let password = request.body.password;
    let firstName = request.body.firstName;
    let lastName = request.body.lastName;
    let ssn = request.body.ssn;
    let dob = request.body.dob;
    let phonenumber = request.body.phonenumber;
    let hiredate = request.body.hiredate;
    let hourlyrate = request.body.hourlyrate;
    let salary = request.body.salary;
    let exempt = request.body.exempt;
    let fedtax = request.body.fedtax;
    let passwordhash = request.body.passwordhash;
    let permissionlevel = request.body.permissionlevel;
    let street = request.body.street;
    let city = request.body.city;
    let state = request.body.state;
    let postalcode = request.body.postalcode;
    let bankname = request.body.bankname;
    let routingnum = request.body.routingnum;
    let accountnum = request.body.accountnum;
    let department = request.body.department;
    let empid = request.body.empid;

    // Ensure the input fields exists and are not empty
    if (username && password) {

        let user = process.env.USR;
        let pwd = process.env.PASSWORD;
        let db = process.env.DATABASE;
        let server = process.env.SERVER;


        const config = {
            connectionLimit: 25,
            user: user,
            password: pwd,
            host: server,
            database: db
        };

        const statement = "update employees e, address a, bank_account b, department d " +
            "set e.firstname = ?, e.lastname = ?, e.ssn = ?, e.dob = ?, e.phone_number = ?, e.hire_date = ?, " +
            "e.exempt = ?, e.hourly_rate = ?, e.salary = ?, e.federal_tax = ?, e.permission_level = ?, " +
            "a.street_address = ?, a.city = ?, a.state = ?, a.postal_code = ?, " +
            "b.bank_name = ?, b.routing_num = ?, b.account_num = ?, d.department_name = ? " +
            "where e.address_id = a.address_id and e.bankacc_id = b.bankacc_id and e.department_id = d.department_id and e.emp_id = ?;";

        const values = [firstName, lastName, ssn, dob, phonenumber, hiredate, exempt, hourlyrate,
            salary, fedtax, permissionlevel, street, city, state, postalcode,
            bankname, routingnum, accountnum, department, empid];

        var pool = mysql.createPool(config);
        pool.query(statement, values, function (err, result) {
            if (err) {
                console.log(err);
                response.send(empid);
                response.end();
            }
            response.json(result);
            response.end();

        });

    } else {
        response.send('Please enter Username and Password!');
        response.end();
    }
});

app.post('/getemp', async function (request, response) {
    // Capture the input fields
    let username = request.body.username;
    let password = request.body.password;
    let empid = request.body.empid;
    // Ensure the input fields exists and are not empty
    if (username && password) {

        let user = process.env.USR;
        let pwd = process.env.PASSWORD;
        let db = process.env.DATABASE;
        let server = process.env.SERVER;


        const config = {
            connectionLimit: 25,
            user: user,
            password: pwd,
            host: server,
            database: db
        };

        const statement = "select * " +
            "from employees e " +
            "left join address a on e.address_id = a.address_id " +
            "left join bank_account b on e.bankacc_id = b.bankacc_id " +
            "left join department d on e.department_id = d.department_id " +
            "left join taxes t on a.state = t.state_name " +
            "where e.delete_indicator = 0 and e.emp_id = ?;";

        var pool = mysql.createPool(config);
        var resp = 'Error';
        pool.query(statement, empid, function (err, result) {
            if (err) {
                console.log(err);
                resp += ': ' + err;
                response.send(resp);
            }
            else if ((result?.length || 0) < 1) {
                console.log("No getemp");
                resp += ': No Result';
                response.send(resp);
            }
            else {
                response.json(result[0]);
            }
            response.end();

        });

    } else {
        response.send('Please enter Username and Password!');
        response.end();
    }
});

app.post('/updatecompanyinfo', async function (request, response) {
    // Capture the input fields
    let username = request.body.username;
    let password = request.body.password;
    let companyname = request.body.companyname;
    let phonenumber = request.body.phonenumber;
    let federalid = request.body.federalid;
    let address = request.body.address;
    let city = request.body.city;
    let state = request.body.state;
    let postalcode = request.body.postalcode;
    let bankname = request.body.bankname;
    let routingnum = request.body.routingnum;
    let accountnum = request.body.accountnum;
    // Ensure the input fields exists and are not empty
    if (username && password) {

        let user = process.env.USR;
        let pwd = process.env.PASSWORD;
        let db = process.env.DATABASE;
        let server = process.env.SERVER;


        const config = {
            connectionLimit: 25,
            user: user,
            password: pwd,
            host: server,
            database: db
        };

        const statement = "update company c, address a, bank_account b " +
            "set c.company_name = ?, c.phone_number = ?, c.federal_id = ?, " +
            "a.street_address = ?, a.city = ?, a.state = ?, a.postal_code = ?, " +
            "b.bank_name = ?, b.routing_num = ?, b.account_num = ? " +
            "where c.address_id = a.address_id and c.bankacc_id = b.bankacc_id and c.company_id = 1;";

        const values = [companyname, phonenumber, federalid,
            address, city, state, postalcode,
            bankname, routingnum, accountnum];

        var pool = mysql.createPool(config);
        var resp = 'Error';
        pool.query(statement, values, function (err, result) {
            if (err) {
                console.log(err);
                response.send(resp);
                response.end();
            }
            response.json(result);
            response.end();

        });

    } else {
        response.send('Please enter Username and Password!');
        response.end();
    }
});

app.post('/getcompanyinfo', async function (request, response) {
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
            connectionLimit: 25,
            user: user,
            password: pwd,
            host: server,
            database: db
        };

        const statement = "select * from company c left join address a on c.address_id = a.address_id left join bank_account b on c.bankacc_id = b.bankacc_id " + 
                            "where c.company_id = 1 limit 1;";

        var pool = mysql.createPool(config);
        var resp = 'Error';
        pool.query(statement, function (err, result) {
            if (err) {
                console.log(err);
                response.send(resp);
                response.end();
            }
            response.json(result[0]);
            response.end();

        });

    } else {
        response.send('Please enter Username and Password!');
        response.end();
    }
});

app.post('/getdeductions', async function (request, response) {
    // Capture the input fields
    let username = request.body.username;
    let password = request.body.password;
    let empid = request.body.empid;
    // Ensure the input fields exists and are not empty
    if (username && password) {

        let user = process.env.USR;
        let pwd = process.env.PASSWORD;
        let db = process.env.DATABASE;
        let server = process.env.SERVER;


        const config = {
            connectionLimit: 25,
            user: user,
            password: pwd,
            host: server,
            database: db
        };

        const statement = "select * from deductions where emp_id = ? and delete_indicator = 0;";

        var pool = mysql.createPool(config);
        var resp = 'Error';
        pool.query(statement, empid, function (err, result) {
            if (err) {
                console.log(err);
                response.send(resp);
                response.end();
            }
            response.json(result);
            response.end();

        });

    } else {
        response.send('Please enter Username and Password!');
        response.end();
    }
});

app.post('/deldeduction', async function (request, response) {
    // Capture the input fields
    let username = request.body.username;
    let password = request.body.password;
    let empid = request.body.empid;
    let name = request.body.name;
    // Ensure the input fields exists and are not empty
    if (username && password) {

        let user = process.env.USR;
        let pwd = process.env.PASSWORD;
        let db = process.env.DATABASE;
        let server = process.env.SERVER;


        const config = {
            connectionLimit: 25,
            user: user,
            password: pwd,
            host: server,
            database: db
        };

        const statement = "update deductions inner join(select deduction_id from deductions where emp_id = ? and deduction_name = ?) d "+ 
                            "on deductions.deduction_id = d.deduction_id set delete_indicator = 1;";

        const values = [empid, name];

        var pool = mysql.createPool(config);
        var resp = 'Error';
        pool.query(statement, values, function (err, result) {
            if (err) {
                console.log(err);
                response.send(resp);
                response.end();
            }
            response.json(result);
            response.end();

        });

    } else {
        response.send('Please enter Username and Password!');
        response.end();
    }
});

app.post('/adddeduction', async function (request, response) {
    // Capture the input fields
    let username = request.body.username;
    let password = request.body.password;
    let empid = request.body.empid;
    let name = request.body.name;
    let flat = request.body.flat;
    let percent = request.body.percent;
    let isflat = request.body.isflat;
    // Ensure the input fields exists and are not empty
    if (username && password) {

        let user = process.env.USR;
        let pwd = process.env.PASSWORD;
        let db = process.env.DATABASE;
        let server = process.env.SERVER;


        const config = {
            connectionLimit: 25,
            user: user,
            password: pwd,
            host: server,
            database: db
        };

        const statement = "insert into deductions (emp_id, deduction_name, isflat, percent, flat_amount, delete_indicator) " +
            "values (?, ?, ?, ?, ?, 0);";

        const values = [empid, name, isflat, percent, flat];

        var pool = mysql.createPool(config);
        var resp = 'Error';
        pool.query(statement, values, function (err, result) {
            if (err) {
                console.log(err);
                response.send(resp);
                response.end();
            }
            response.json(result);
            response.end();

        });

    } else {
        response.send('Please enter Username and Password!');
        response.end();
    }
});

app.post('/addemp', async function (request, response) {
    // Capture the input fields
    let username = request.body.username;
    let password = request.body.password;
    let firstName = request.body.firstName;
    let lastName = request.body.lastName;
    let ssn = request.body.ssn;
    let dob = request.body.dob;
    let phonenumber = request.body.phonenumber;
    let hiredate = request.body.hiredate;
    console.log(dob + " " + hiredate);
    let hourlyrate = request.body.hourlyrate;
    let salary = request.body.salary;
    let exempt = request.body.exempt;
    let fedtax = request.body.fedtax;
    let passwordhash = request.body.passwordhash;
    let permissionlevel = request.body.permissionlevel;
    let street = request.body.street;
    let city = request.body.city;
    let state = request.body.state;
    let postalcode = request.body.postalcode;
    let bankname = request.body.bankname;
    let routingnum = request.body.routingnum;
    let accountnum = request.body.accountnum;
    let department = request.body.department;
    console.log(passwordhash);

    // Ensure the input fields exists and are not empty
    if (username && password) {

        let user = process.env.USR;
        let pwd = process.env.PASSWORD;
        let db = process.env.DATABASE;
        let server = process.env.SERVER;


        const config = {
            connectionLimit: 25,
            user: user,
            password: pwd,
            host: server,
            database: db
        };

        const statement = "call add_emp(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

        const values = [firstName, lastName, ssn, dob, phonenumber, hiredate, exempt, hourlyrate,
                        salary, fedtax, passwordhash, permissionlevel, street, city, state, postalcode,
                        bankname, routingnum, accountnum, department];

        var pool = mysql.createPool(config);
        var empid = "-99";
        pool.query(statement, values, function (err, result) {
            if (err) {
                console.log(err);
                response.send(empid);
                response.end();
            }
            if (password === password)
                empid = result[0][0].emp_id;
            else
                empid = '-999';
            console.log(empid);
            response.json(result[0][0]);
            response.end();

        });

    } else {
        response.send('Please enter Username and Password!');
        response.end();
    }
});

app.post('/getemplist', async function (request, response) {
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
            connectionLimit: 25,
            user: user,
            password: pwd,
            host: server,
            database: db
        };

        const statement = "select * from employees e " +
            "left join address a on e.address_id = a.address_id " +
            "left join bank_account b on e.bankacc_id = b.bankacc_id " +
            "left join department d on e.department_id = d.department_id " +
            "left join taxes t on a.state = t.state_name " +
            "where e.delete_indicator = 0;";

        var pool = mysql.createPool(config);
        var resp = 'Error';
        pool.query(statement, function (err, result) {
            if (err) {
                console.log(err);
                response.send(resp);
                response.end();
            }
            response.json(result);
            response.end();

        });

    } else {
        response.send('Please enter Username and Password!');
        response.end();
    }
});

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
            connectionLimit: 25,
            user: user,
            password: pwd,
            host: server,
            database: db
        };

        const statement = "SELECT * FROM employees WHERE emp_id = ?;";

        var pool = mysql.createPool(config);
        var privelege = 'Error';
        pool.query(statement, username, function (err, result) {
            if (err) {
                console.log(err);
                privelege = err;
                response.end();
            }
            else if ((result?.length || 0) < 1) {
                console.log("No ");
                privelege += ': Incorrect Login';
            }
            else if (password === result[0].password_hash)
                privelege = result[0].permission_level;
            else
                privelege = 'Denied';
            response.send(privelege);
            response.end();

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
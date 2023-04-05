const express = require("express");
const app = express();
const ejs = require('ejs');
const bodyParser = require("body-parser");
const PORT = process.env.PORT||7010;

app.set('view engine', 'ejs');
app.use(bodyParser.urlencoded({extended:true}));
app.use(bodyParser.json());

const UserRoutes = require("./Routes/UserRoutes");
app.use("/users", UserRoutes);
app.use("", UserRoutes);

const DoctorRoutes = require("./Routes/DoctorRoutes");
app.use("/doctors", DoctorRoutes);

const PatientRoutes = require("./Routes/PatientRoutes");
app.use("/patients",PatientRoutes);

app.listen(PORT, ()=>{console.log(`http://localhost:${PORT}`)});
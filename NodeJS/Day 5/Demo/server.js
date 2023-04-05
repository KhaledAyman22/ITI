//#region Requires
const express = require("express");
const app = express();
const path = require("path");
const bodyParser = require("body-parser");
const logging = require("./Middlewares/loggingMW");
const PORT = process.env.PORT||7010;
//#endregion
//#region MiddleWares
app.use(bodyParser.urlencoded({extended:true}));
app.use(bodyParser.json());
app.use(logging)
//#endregion
//#region End Points
    //#region Students Routes
        const StudentsRoutes = require("./Routes/StudentsRoutes");
        app.use("/api/students",StudentsRoutes);
   //#endregion
    //#region Courses
        const CoursesRoutes = require("./Routes/CoursesRoutes");
        app.use("/api/courses",CoursesRoutes);
    //#endregion

    //#region Auth [Registration - Login]
        const UsersRoutes = require("./Routes/UsersRoutes");
        app.use("/api/users",UsersRoutes);
    //#endregion

//#endregion
app.listen(PORT, ()=>{console.log("http://localhost:"+PORT)});
//170 ==> 82 ==> 25
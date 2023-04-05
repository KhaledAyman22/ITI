const Ajv = require("ajv");
const ajv = new Ajv(); // Schema ==> compile(schema)(body)

//#region Students Schema
const StudentSchema = {
    type:"object",
    properties:{
        name:{type:"string", pattern:"^[a-zA-Z]+$"},
        age:{type:"number",minimum:2},
        dept:{type: "string",enum:["PD","SWA","Mobile"],minLength:2},
        courses:{type:"array",items:{type:"number"}}
    },
    required:["name", "age", "dept","courses"],
    additionalProperties:false
}
module.exports = ajv.compile(StudentSchema);//validate(body)==> true || false ===> method()
//#endregion
const Ajv = require("ajv");
const ajv = new Ajv(); // Schema ==> compile(schema)(body)


//#region Courses Schema
const CourseSchema = {
    type:"object",
    properties:{
        name:{type:"string", pattern:"^[a-zA-Z]+$"},
        duration:{type:"string"},
        desc:{type: "string"}
    },
    required:["name", "duration", "desc"],
    additionalProperties:false
}
module.exports = ajv.compile(CourseSchema);
//#endregion
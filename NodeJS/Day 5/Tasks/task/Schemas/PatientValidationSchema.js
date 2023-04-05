const Ajv = require("ajv");
const ajv = new Ajv();
require("ajv-formats")(ajv);

const PatientSchema = {
    type: "object",
    properties: {
        name: {type: "string", pattern: "^[a-zA-Z]+ [a-zA-Z]+$"},
        age: {type: "string"},
        email: {type: "string", pattern: "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"},
        password: {type: "string", pattern: "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$"},
        entryDate: {type: "string", format: "date"}
    },
    required: ["name", "age", "email", "entryDate"],
    additionalProperties: false
}

module.exports = ajv.compile(PatientSchema);
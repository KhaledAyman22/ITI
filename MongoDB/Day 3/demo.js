//create collection
//db.xxx.insert()
db.createCollection("students",{
    validator:{
        $jsonSchema:{
            bsonType:"object",
            properties:{
                firstName:{ bsonType:"string"},
                lastName:{bsonType:"string"},
                age:{bsonType:"number",maximum:20},
                
            }
        } //jsonSchema
    }// validator
})

//update schame after creation
db.students.runCommand("collMod",{
    validator:{
        $jsonSchema : {
                    bsonType : "object",
                    required:["firstName","lastName"],
                    additionalProperties:false,
                    properties : {
                        _id:{bsonType:"objectId"},
                        firstName : {
                            "bsonType" : "string"
                        },
                        lastName : {
                            "bsonType" : "string"
                        },
                        age : {
                            "bsonType" : "number",
                            "maximum" : 20.0
                        }
                    }
       } //jsonSchema
    }// validator
    ,validationAction:"error",
    validationLevel:"strict"
        
})

db.students.insertOne({})
db.students.insertOne({firstName:"hadeer",lastName:"Mohamed",age:18 ,_id:8})
db.getCollectionInfos({name:"students"})

db.students.updateOne({"_id" : ObjectId("641ea1e79493b37d33e6df83")},{$set:{age:15,salary:9000}})
typeof db.students.findOne()

use library
db.Books.createIndex({Title:1},{name:"TitleName",background:true})
db.Books.find({})
db.Books.find({ISBN:7}).explain()



db.Books.aggregate([{
    $match:{Borrow:true}
},{
    $group:{_id:"$Cat",
   PagesAvg: {$avg:"$Pages"}}
},{
    $project:{_id:0,PagesAvg:1,"CatName":"$_id"}
},{
    $sort:{
        CatName:-1
    }
},{$out:"CatAvg"}])

use ITI
db.instructors.aggregate([{
    $match:{age:{$gte:21}}
},{
    $group:{
        _id:{age:"$age",city:"$address.city"},
        count:{$sum:1}
    },
    
}])

let depts=[{
    _id:1,
    name:"SD",
    location:"1'stFloor",
    phone:"0123456"
},
{
    _id:2,
    name:"OS",
    location:"2'stFloor",
    phone:"0123456"
}
]


let students=[{
    firstName:"ahmed",
    lastName:"ahmed",
    addresses:[
        {
            city:"mansoura",
            street:30
        },
        {
            city:"alex",
            street:24
        }
    ],
    department:1,
    subjects:[
    2,3
    ]
},
{
firstName:"hesham",
    lastName:"mohamed",
    addresses:[
        {
            city:"mansoura",
            street:30
        },
        {
            city:"alex",
            street:24
        }
    ],
    department:1,
    subjects:[
    2,3
    ]
}
]
db.departments.insertMany(depts)

db.students.insertMany(students)
db.students.find()

db.students.aggregate([{
    $lookup:{
        from:"departments",
        localField:"department",
        foreignField:"_id",
        as:"dept"
    }
}])
//unwind
db.students.find({})




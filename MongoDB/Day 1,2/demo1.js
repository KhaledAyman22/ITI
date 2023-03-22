db.getName();
db.employees.insertOne({_id:1,name:"samia"})
db.employees.insertOne({id:2,name:"aya"})
db.employees.insertOne({_id:"jhkj",name:"aya"})
db.employees.find()

///create collection
db.createCollection("students")
db.students.insert({})


//primaryKey
//_id    objectId   BSON TYpes
//_id :7

//insert
db.instructors.insertOne({_id:20,firstName:"gana",lastName:"Ahmed"})
db.instructors.insertMany([{},{},{}])
let instructorsArray2=[{_id:10,firstName:"noha",lastName:"hesham",
                age:29,salary:3500,
                address:{city:"cairo",street:10,building:8},
                courses:["js","mvc","signalR","expressjs"]},
                
                {_id:11,firstName:"mona",lastName:"ahmed",
                age:23,salary:3600,
                address:{city:"cairo",street:20,building:8},
                courses:["es6","mvc","signalR","expressjs"]},
                
                {_id:12,firstName:"mazen",lastName:"mohammed",
                age:11,salary:7040,
                address:{city:"Ismailia",street:10,building:8},
                courses:["asp.net","mvc","EF"]},
                
                {_id:13,firstName:"ebtesam",lastName:"hesham",
                age:27,salary:7500,
                address:{city:"mansoura",street:14,building:3},
                courses:["js","html5","signalR","expressjs","bootstrap"]}
               
		
		];

db.instructors.insertMany(instructorsArray2)
db.instructors.find()   //select * from instructors
db.instructors.findOne()

//find(condition, projection)
db.instructors.find({},{_id:0,firstName:true, lastName:1})
db.instructors.find({},{salary:1})

//with conditions
db.instructors.find({age:21})
db.instructors.find({firstName:"mona"})
db.instructors.find({age:21,lastName:"ahmed"},{firstName:1})   //age==21



db.instructors.find({firstName:"mona"},{lastName:"omar"},{firstName:
1,lastName:1})

//find operators
//1-comparison operators
//2-logical 
//3-Array 
//4-element 
//5-embeded object

//embeded object
db.instructors.find({"address.city":"cairo"})
db.instructors.find({address:{city:"cairo"}})  //if address=={city:"cairo"}
db.instructors.find({"address.city":"cairo"},{"address.city":1})
db.instructors.find({"address.city":"cairo"},{address:{city:1}})

//comparison operators (gt , gte, lt, lte, ne , eq)

db.instructors.find({age:{$gte:21},lastName:"hesham"})
db.instructors.find({age:{$gte:21}})
db.instructors.find({age:{$eq:21}})
db.instructors.find({age:{$in:[21,29]}})  //not range

//logical operators and ,or nor..
db.instructors.find({$or:[{age:21},{lastName:"hesham"}]})
db.instructors.find({$or:[{age:{$gt:21}},{lastName:"hesham"}]})

//element operators
//1-exists
db.instructors.find({courses:{$exists:true}}).forEach(ins=>{
    print(`${ins.firstName} , courses: ${ins.courses.length}`)
})

//2-type
db.instructors.find ()
db.instructors.find ({salary:{$type:"number"}})

//array operators
db.instructors.find ({courses:"mvc"})
db.instructors.find({$and:[{courses:"signalR"},{courses:"html5"}]})
//1-all
db.instructors.find ({courses:{$all:["signalR","html5"]}})

2-$size
    db.instructors.find({courses:{$size:3}})
    
        db.instructors.find()
        db.instructors.deleteOne({firstName:"gana"})
         db.instructors.deleteMany({})
db.instructors.insert({_id:1,firstName:"gana",lastName:"Ahmed"})
//updateMany (condition, updateCommand, options )
 db.instructors.find()
// 1-change field value
 db.instructors.updateOne({firstName:"ebtesam",age:21},{$set:{lastName:"aly"}})
  db.instructors.updateOne({firstName:"mona"},{$set:{lastName:"aly"}})
// 2-add fields
    db.instructors.updateOne({firstName:"gana"},{$set:{age:30,salary:4000}})
//3-remove field
db.instructors.updateMany({firstName:"noha"},{$unset:{salary:"kljjkhh"}})
//4-rename
db.instructors.updateMany({},{$set:{Gender:"male"}})

   db.instructors.updateMany({},{$rename:{Gender:"gender"}})  
   db.instructors.updateMany({firstName:"gana"},{$rename:{gender:"gen"}}) 
//upsert
db.instructors.updateMany({firstName:"mirah"},{$set :{lastName:"Anas"}},{upsert:true})  


//address upnormal field obj
//1-change field
db.instructors.updateMany({_id:6},{$set:{"address.street":30}})
//2-add field
db.instructors.updateMany({_id:6},{$set:{"address.floor":5}})
//3-rename
db.instructors.updateMany({_id:6},{$rename:{"address.floor":"address.floor Num"}})
//4-remove
db.instructors.updateMany({_id:6},{$unset:{"address.floor Num":"hghg"}})
          db.instructors.find()

//          Array
db.instructors.updateMany({_id:6},{$set:{courses:"es6"}})

//1-change value for specified element by index
db.instructors.updateMany({_id:7},{$set:{"courses.0":"js"}})

//2-change value for specified element annonymous
db.instructors.updateMany({_id:7,courses:"mvc"},{$set:{"courses.$":"mongodb"}})
//3-push new element
db.instructors.updateMany({_id:7},{$push:{courses:"nodeJS"}})

db.instructors.updateMany({_id:7},{$addToSet:{courses:"js"}})

//4-remove specified element

db.instructors.updateMany({_id:7},{$pop:{courses:-1}})
db.instructors.updateMany({_id:7},{$pull:{courses:"nodeJS"}})
 db.instructors.find()
 
// setTimeout(()=>{console.log("Hii")},2000)
// var x = 10;
// var y= 20;
// // cons
// console.log(x);

/**
 * 4 Main Categories [Objects] js
 * 1- Built-In Objeects [Number - Array - Function - Error - .....]
 * 2- DOM [document]
 * 3- BOM [Window [glopal] [navigation - ...]]
 * 4- Custom Object
 */

/** 4 Main Categories [Modules] Node Js
 * 
 * 1- Glopal Modules [without Require] [console - setTimeOut - SetInterval - process - require - .....]
 * 2- Built-In Modules [Require] [os - fs - http - ...]
 * 3- third Party Module [install npm] [express - nodemon - ......]
 * 4- custom Module [ur Own Module]
 */


//import {abc} from '' XXXXXXXXXXXX
//require("abc") ==> Built-In [os - fs - http] 
//require("./xyz") ==> Custom Module

//Global Modules
// // console.log(global);
// process.stdout.write("Hello\n");
// console.log("Hii");
// console.log("Hii");
// process.stdout.write("Hello\n");
// process.stdout.write("Hello\n");


// import { x } from '';
// x

// const os = require("os");
// // console.log(os.hostname());
// console.log(os.platform());


//Third Party Module
/**
 * nodemon [Watching ]==> save  ==> re-Run [npm i nodemon -g]
 *  Run ==> [node fileName.js] ==> nodemon fileName.js
 */


/**Built-In [fs - http] */
/**
 * fs ==> require("fs")
 * fs [Read - Create - Update - Delete]
 */

const fs = require("fs");
// fs.readFile("file.txt",(err,data)=>{
//     if(err){
//         console.log(err);
//     }
//     else{
//         console.log(data);
//     }
// })


//1st So
// fs.readFile("file.txt",(err,data)=>{
//     if(err){
//         console.log(err);
//     }
//     else{
//         console.log(data.toString());
//     }
// })

// console.log("After ReadFile Async")

// fs.readFile("file.txt","utf-8",(err,data)=>{
//     if(err){ 
//         console.log(err);
//     }
//     else{
//         console.log(data);
//     }
// })


// var read = fs.readFileSync("file.txt","utf-8")
// console.log(read);

// fs.writeFile("file.txt","New Text",()=>{})
// fs.writeFile("file2.txt","New File 2 Text",()=>{})

// fs.appendFile("file3.txt"," appended",()=>{})

// fs.unlinkSync("file3.txt")
// fs.mkdirSync("NewFolder")
// fs.writeFile("file4.txt","asdasd",()=>{})
// process.chdir("NewFolder")
// fs.writeFile("file4.txt","asdasd",()=>{})
// process.chdir("..")
// fs.writeFile("file5.txt","asdasd",()=>{})


//for loop[5000] file ==> append(" Hello ")
// for(let i=0; i<5000; i++){
//     fs.appendFileSync("file.txt"," Hello World")
// }
//Read File Chuncks [16kb]
let readMyFile = fs.createReadStream("file.txt",{encoding:"utf-8", highWaterMark:16*1024});

// readMyFile.on("error",(err)=>{console.log("7asal Error")});
// readMyFile.on("data",(data)=>{console.log(data.toString().length)});
// var counter = 0;
let writeMyFile = fs.createWriteStream("newfile.txt");
// readMyFile.on("data",(data)=>{
//     // counter++;
//     // fs.writeFileSync("newfile.txt","");
//         console.log(data.length)
//         writeMyFile.write(data)
//         }
//     );
// readMyFile.on("open",()=>{console.log("Opened Successfully")});
// readMyFile.on("end",()=>{console.log("Closed Bye Bye")});

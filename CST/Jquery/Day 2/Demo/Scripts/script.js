$(function(){  
    //#region AddClass | RemoveClass | ToggleClass
        // $("#btnAdd").click(function(){
        //     $("#d1").addClass("myClass");
        // })
        // $("#btnRemove").click(function(){
        //     $("#d1").removeClass("myClass");
        // })
        // $("#btnToggle").click(function(){
        //     $("#d1").toggleClass("myClass");
        // })
    //#endregion

    //#region Siblings Selectors
        //Direct Sibling Selector [Direct After h1]
        // $("h1+h2").css({"color":"red","backgroundColor":"aqua","textAlign":"center"})
        // $("h1").next("h2").css({"color":"red","backgroundColor":"aqua","textAlign":"center"})

        
        //General Sibling Selector [General After h1]
        // $("h1~h2").css({"color":"red","backgroundColor":"aqua","textAlign":"center"})
        // $("h1").nextAll("h2").css({"color":"red","backgroundColor":"aqua","textAlign":"center"})
        
        //General [After & Brfore]
        // $("h1").siblings("h2").css({"color":"red","backgroundColor":"aqua","textAlign":"center"})

        //Context
        // $("h2","div").css({"color":"red","backgroundColor":"aqua","textAlign":"center"})
        // $("h2").eq(3).css({"color":"red","backgroundColor":"aqua","textAlign":"center"})
        // $("h2,div").css({"color":"red","backgroundColor":"aqua","textAlign":"center"})
        // $("div h2").css({"color":"red","backgroundColor":"aqua","textAlign":"center"})

    //#endregion

    // console.log($)
    // console.log(jQuery)

    // console.log($())
    // console.log(jQuery())

    // console.log(typeof $)
    // console.log(typeof jQuery)

    // console.log(typeof $())
    // console.log(typeof jQuery())

    // console.log($.type( "asdas" ));//string
    // console.log($.type( $() ));//object
    // console.log($.type( jQuery() ));//object

    //#region Attributes
        // $("#btnShow").click(function(){
        //     // $("#img1").show();
        //     // $("#img1").css("display","inline");
        //     $("#img1").removeAttr("hidden");
        // })
        // $("#btnHide").click(function(){
        //     $("#img1").attr("hidden","hidden");
        // })
    //#endregion

    //#region each
        //1- $("").each(function(idx,elem){})
        // $("ul li").each(function(idx,elem){
        //     console.log(idx, elem);
        // })

        //2- $.each( $("#"), function(idx,elem){})
        // $.each($("ul li"),function(idx,elem){
        //     console.log(idx, elem);
        // })
    //#endregion

    //#region Append | AppendTo | PrePend | PrePendTo
    // $("#btnAppend").click(function(){
    //     // $("#d1").append( $("#img1") );
    //     // var im = document.createElement("img");
    //     // im.src = "../Images/1.jpg";
    //     //var im = $("<img src='../Images/1.jpg'/>");

    //     // $("#d1").append( "<img src='../Images/1.jpg'/>" );
    // })
    // $("#btnAppendTo").click(function(){
    //     $("#img1").appendTo( $("#d1") );
    // })
    // $("#btnPreAppend").click(function(){
    //     $("#d1").prepend( $("#img1") );
    // })
    // $("#btnPreAppendTo").click(function(){
    //     $("#img1").prependTo( $("#d1") );
    // })
    //#endregion

    //#region Events[On|Off|One]
    // document.getElementById("btnOn").onclick = function(){alert("hi")}
    // document.getElementById("btnOn").addEventListener("click",function(){}) 
    // $("#btnOn").on("click",function(){
    //     $("#d1").append("<p>Hello</p>");
    //     // $("#btnOn").off("click");
    // })
    // $("#btnOn").on("mouseover",function(){
    //     console.log("Hi")
    // })
    // $("#btnOff").click(function(){
    //     $("#btnOn").off("click");
    // })
    // $("#btnOne").one("click",function(){
    //     $("#d1").append("<p>Hello</p>");
    // })

    // $("#btnEmpty").click(function(){
    //     $("p").empty();
    // })
    // $("#btnRemove").click(function(){
    //     $("p").remove();
    // })
    // $("#btnRemoveLast").click(function(){
    //     $("p:last").remove();
    // })

    //Create ur Own Event
    // $("#btnOn").on("myEvent",function(){
    //     alert("Event Fired");
    // })
    // setTimeout(function(){
    //     $("#btnOn").trigger("myEvent")
    // },3000)

    //Event Delegation
        // $("#d1").on("click","#b1",function(){
        //     console.log("Hiii")
        // })
    //#endregion

    //#region Ajax
    // $("#btnAjax").click(function(){

        // var xhr = new XMLHttpRequest();//{open}

        // //1-open
        // xhr.open("GET","https://jsonplaceholder.typicode.com/users");
        // //3-event
        // xhr.onreadystatechange = function(){
        //     if(xhr.readyState == 4){
        //         if(xhr.status >=200 && xhr.status<300){
        //             // console.log(xhr.response);//string
        //             // console.log(xhr.response[0]);//[
        //             // $("#d1").append(xhr.response)
        //             // console.log( JSON.parse(xhr.response) );//arr
        //             var data = JSON.parse(xhr.response);
        //             for(var i=0; i<data.length;i++){
        //                 $("#d1").append("<p>"+data[i].name+"</p>")
        //             }
        //         }
        //     }
        // }
        // //2-send
        // xhr.send("")



        // $.ajax({
        //     method:"",
        //     url:"",
        //     data:{},
        //     data:[{},{}],
        //     succsess:function(){},
        //     error:function(){}
        // })
    // })
    //#endregion

    //#region Animation
    $("#btnShow").click(function(){
        $("#img1").show("fold",3000)
    })
    $("#btnHide").click(function(){
        $("#img1").hide("explode",3000)
    })
    $("#btnAnimate").click(function(){
        $("#img1").animate({left:"200px"},5000,"linear");//easing["linea","swing",.....]
        $("#img2").animate({left:"200px"},5000,"swing");//easing["linea","swing",.....]
        $("#img3").animate({left:"200px"},5000,"easeOutBounce");//easing["linea","swing",.....]
    })
    //#endregion
})





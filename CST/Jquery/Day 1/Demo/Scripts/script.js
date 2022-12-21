// onload = function () {    
//     document.getElementById("myh").addEventListener("click",function () { 
//         alert("Hii");
//     })
//     console.log($("#myh"))
//     console.log($(".hh"))
// }



// document.getElementById("myh").addEventListener("click",function () { 
//     alert("Hii");
// })



// $(document).ready(function () { 
//     console.log($("#myh"))
//  })


//  $('document').ready(function () { 
//     console.log($("#myh"))
//  })

//  $(function () { 
//     console.log($("#myh"))
//  })

 //onload = function(){} ====> $(function(){})

$(function () { 
    // console.log($("#myh"))//
    // console.log($("#myh")[0])//Native HTML Element
    // // $("#myh")[0].style.color = "red";

    // console.log($("#myh").get(0))//Native HTML Element
    // // $("#myh").get(0).style.color = "red";

    // console.log($("#myh").eq(0))//
    // // $("#myh").eq(0).css("color","blue")
    // $("#myh").css("color","blue")

    // document.getElementsByClassName("hh")[0].style.color = "red"
    // document.getElementsByClassName("hh")[1].style.color = "red"

    // $(".hh").css("color","red");
    // $(".hh").eq(0).css("color","red");
    // $(".hh").eq(1).css("color","red");

    // $(".hh").get(1).css("color","red");//error ==> <h1></h1>

    // $(".hh").css("color","red").css("background-color","blue").css("color","yellow")

    // $(".hh").css({"color":"red", "backgroundColor":"yellow"});
    // $(".hh").style.color = "red";


    //innerHTML, innerText ===> ?? html(), text()
    // console.log(document.getElementById("myh").innerHTML);
    // console.log(document.getElementById("myh").innerText);
    
    // document.getElementById("myh").innerHTML = "<u>Hiii</u>";
    // document.getElementById("myh").innerText = "<u>Welcome</u>";

    // console.log($("#myh").html())
    // console.log($("#myh").text())

    // $("#myh").html("<u>Hiiii</u>")
    // $("#myh").text("<u>Hiiii</u>")

    // for(var i=0; i<$(".hh").length;i++){
    //     console.log($(".hh").eq(i).html())
    // }
    // console.log($(".hh").get(0).innerHTML)

    //#region Events
        // $("#myh")
        //         // .css("color","red")
        //         .click(function (event) { 
        //             // alert("Hiii")
        //             // console.log(this);
        //             // this.innerHTML = "Clicked"
        //             // console.log( $(this) )
        //             // console.log(event);
        //             // console.log(event.target.innerHTML);
        //             // event.target.innerHTML = "Clicked"
        //             $(this).css({"color":"red"}).html("Clicked");
        //             // $(this).html("Clicked");
        //         })



        // document.getElementById("myh").style.color = "red";

        // document.getElementById("myh").addEventListener("click",function () { 
        //     document.getElementById("myh").innerHTML = "Clicked";
        //  })        
    //#endregion


    //#region Filter
    // $("ul li").css("color","red");
    // $("ul li:first").css("color","red");
    // $("ul li:eq(0), ul li:eq(1)").css("color","red");
    // $("ul li").filter(":eq(0),:eq(1)").css("color","red");
    // console.log(
    //         $("ul li").filter(function () { 
    //             // console.log(this);//Native || JQueryXXXXX
    //             // console.log($(this).attr("id"));
    //             // $(this).attr("id")
    //             // return this.id == "l1"||this.id == "l3";
    //             return $(this).attr("id")=="l1" || $(this).attr("id") == "l3"
    //         })
    //  )




    // function myFilter() { 
    //     var arr = [];
    //     var elems = document.getElementsByTagName("li");
    //     for(var i=0;i<elems.length;i++){
    //         if(elems[i].id == "l1")
    //             arr.push(elems[i]);
    //     }
    //     return arr;
    // }

    // console.log(myFilter());

    //#endregion

    //#region Animation [show|hide|fadeIn|fadeOut|fadeTo|slideToggle]
    $("#btnShow").click(function () { 
        $("#img1").show(3000);//fast|normal|slow || duration
     })
    $("#btnHide").click(function () { 
        $("#img1").hide(3000);//fast|normal|slow || duration
     })
    $("#btnFadeIn").click(function () { 
        $("#img1").fadeIn(3000);
     })
    $("#btnFadeOut").click(function () { 
        $("#img1").fadeOut(3000);
     })
    $("#btnFadeTo").click(function () { 
        $("#img1").fadeTo(3000,0.2);//opacity:0->1 ===> 0, 0.1, 0.2, 0.9, 1
        // $("#img1").fadeTo(3000,0);//opacity:0->1 ===> 0, 0.1, 0.2, 0.9, 1
     })
    $("#btnSlideToggle").click(function () { //Show&Hide
        $("#img1").slideToggle(3000);
     })

    $("#btnChange").click(function () { 
        $("#img1").attr("src","../Images/1.jpg")
     })
    //#endregion
})

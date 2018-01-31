var colors = ['#16a085', '#27ae60', '#2c3e50', '#f39c12',
    '#e74c3c', '#9b59b6', '#FB6964', '#342224', "#472E32",
    "#BDBB99", "#77B1A9", "#73A857"
];

var curQuote = '',
    curAuth = '';

function getQuote() {
    // $.ajax({
    //     url: "http://api.forismatic.com/api/1.0/?method=getQuote&key=457653&format=json&lang=en",
    //     Accept: "application/json",
    //     success: function (result) {
    //         console.log(result);
    //         // console.log(result.contents.quotes[0].quote);
    //         // console.log(result.contents.quotes[0].author);
    //     }
    // });
    let idx = Math.floor((Math.random() * 30));
    curQuote = quotesData[idx].content;
    curAuth = quotesData[idx].title;
    
    
    $(".quote-text").animate({
        opacity: 0
    },500 , function(){
        $(this).animate({
            opacity:1
        },500);
        $('#text').html(curQuote);
    });

    $("quote-author").animate({
        opacity: 0
    },500 , function(){
        $(this).animate({
            opacity:1
        },500);
        $('#author').html('<strong>- </strong>' + curAuth);
    });
}

function changeColor(){
    let idx = Math.floor((Math.random() * colors.length));
    // $('body').css("background-color",colors[idx]);
    $('.button').css('background-color',colors[idx]);
    $('#text').css('color', colors[idx]);
    $('#author').css('color', colors[idx]);
    $('.quote-text i').css('color',colors[idx]);
    $("body").animate({
        "background-color": colors[idx],
    }, 1000);
}
$(document).ready(function () {
    getQuote();
    changeColor();
    $("#new-quote").on('click', () => {
        getQuote();
        changeColor();
    });

    $('#facequo').on('click', () => {
        var shareurl = $(this).data('shareurl');
        window.open('https://www.facebook.com/dialog/sharer.php?u=' + escape("abcde") + '&t=' + document.title, '',
            'menubar=no,toolbar=no,resizable=yes,scrollbars=yes,height=300,width=600');
        return false;
    });

    $('#twitquo').on('click',()=>{
        window.open('https://twitter.com/intent/tweet?text=' + encodeURIComponent(curQuote));
    });
});

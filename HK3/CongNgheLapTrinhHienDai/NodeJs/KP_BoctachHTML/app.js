var express = require('express'),
    request = require('request'),
    cheerio = require('cheerio');

var app = express();

app.use(express.static('public'));

app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');

app.get('/', (req, res) => {
    request('http://vnexpress.net', (err, resp, body) => {
        if(err){
            console.log(err);
            res.render('trangchu',{html:"NOT FOUND"});
        } else{
            // console.log(body);
            $ = cheerio.load(body);
            let ds = $(body).find("img.lazyInitial");
            
            ds.each((idx, e)=>{
                // console.log($(this).text());
                console.log(e["attribs"]["src"]);

            });
            res.render('trangchu',{html:body});
        }
    });
});


app.listen(3000, () => {
    console.log('Connect succesful');
})
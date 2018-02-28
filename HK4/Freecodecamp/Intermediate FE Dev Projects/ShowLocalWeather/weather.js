let url = '';
let api = 'https://fcc-weather-api.glitch.me/api/current?';
let lat, lng;
let tempUnit = 'C';
let curTemp;

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition((pos) => {
            lat = pos.coords.latitude;
            lng = pos.coords.longitude;
            url = api + 'lat=' + lat + '&lon=' + lng;
            console.log(pos);
            getWeather(pos);
            
        });
    } else {
        console.log('Geolocation is not supported by this browser.');
    }
};

function getWeather(position){
    $.ajax({
        url: url,
        Accept: "application/json",
        success: function (rs) {
            console.log(rs);
            // $('#city').text(r)
            $('#city').text(rs.name);
            $('#country').text(', ' + rs.sys.country);
            curTemp = rs.main.temp
            $('#temp').text(curTemp + " " + String.fromCharCode(176));
            $("#tempunit").text(tempUnit);
            $('#descrip').text(rs.weather[0].main);
        }
    });
}

$(document).ready(() => {
    getLocation();
    $('#tempunit').on('click',()=>{
        let newTempUnit = $('#tempunit').text() == 'C' ? 'F' : 'C';
        $('#tempunit').text(newTempUnit);
        if(newTempUnit == 'F'){
            let fahTemp = Math.round(parseInt($("#temp").text()) * 1.8 + 32);
            $('#temp').text(fahTemp + " " + String.fromCharCode(176));
        } else{
            $('#temp').text(curTemp + " " + String.fromCharCode(176));
        }
    });
});
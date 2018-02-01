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
            $('#temp').text(rs.main.temp) + " " + String.fromCharCode(176);
            $("#tempunit").text(tempUnit);
            $('#descrip').text(rs.weather[0].main);
        }
    });
}

$(document).ready(() => {
    getLocation();
});
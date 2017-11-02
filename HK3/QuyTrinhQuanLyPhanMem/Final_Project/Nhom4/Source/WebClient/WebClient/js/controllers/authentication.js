//chart.js
angular
    .module('app')
    .controller('AuthenticationCtrl', AuthenticationCtrl)

AuthenticationCtrl.$inject = ['$scope', '$state', '$http', 'store', 'httpModule', 'tokenModule'];

function AuthenticationCtrl($scope, $state, $http, store, httpModule, tokenModule) {
    //Login function

    //console.log('AuthenticationCtrl');

    var user = store.get('user');

    var qrcode = new QRCode(document.getElementById("qrcode"), {
        text: user.secretKey,
        width: 250,
        height: 250,
        colorDark: "#000000",
        colorLight: "#ffffff",
        correctLevel: QRCode.CorrectLevel.H
    });

}
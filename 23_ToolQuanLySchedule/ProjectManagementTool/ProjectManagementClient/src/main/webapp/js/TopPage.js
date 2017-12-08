//call rest api get list project
var lstPjUrl = "http://192.168.10.143:8080/ProjectManagementServer/ws/projects";
// var lstPj = [{
//     "project_id": "",
//     "project_name": ""
// }];

var lstProject = ["Project1", "Project 2", "Project 3"];

// for (i = 0; i < lstProject.length; i++) {

//     var newLI = document.createElement("li"),
//         displayLstProject = document.getElementById("lstProjectMenu"); // cache the unordered list
//     var a = document.createElement('a'),
//         linkText = document.createTextNode(lstProject[i]);

//     a.appendChild(linkText);
//     a.href = "ProjectPage.html";
//     // add the a node to the li
//     newLI.appendChild(a);
//     displayLstProject.appendChild(newLI);
// }
// alert("Top page");
function getDataServer() {
	return new Promise((resolve, reject) => {
		$.getJSON(lstPjUrl, (lst) => {
			console.log(lst);
			if (lst != null) {
				resolve(lst);
			}
			else {
				resolve(null);
			}
		});
	});
};
 
getDataServer().then(rs => {
    var i;
    for (i = 0; i < rs.length; i++) {
        var newLI = document.createElement("li"),
            displayLstProject = document.getElementById("lstProjectMenu"); // cache the unordered list
        var a = document.createElement('a'),
            linkText = document.createTextNode(rs[i].project_name);

        a.appendChild(linkText);
        a.href = "ProjectPage.html";
        a.id = rs[i].id;
        // add the a node to the li
        newLI.appendChild(a);
        displayLstProject.appendChild(newLI);
    }
    alert("Top page");
});
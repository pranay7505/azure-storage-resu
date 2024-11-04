window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
})

const functionApiUrl = "https://getresumecounter7505.azurewebsites.net/api/GetResumeCounter?code=jLHDrE7V0mEDYlOYzbF74xeP0edBN4L2Swuqc29M19eIAzFuiEY7BA%3D%3D";
const localFunctionApi = 'http://localhost:7072/api/GetResumeCounter';

const getVisitCount = () => {
    let count = 30;
    fetch(functionApiUrl).then(response => {
        return response.json()
    }).then(response => {
        console.log("Website called function API.");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(errror){
        console.log(error);
    });
    return count;
}
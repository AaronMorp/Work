$("#searchName").click(function () {
    var searchNames = $("#searchNames").val();
    var error = $(".error");

    if (searchNames == "") {
        error.html("Enter search query");
        console.log("Error, enter in a search query");
    }
    else {
        console.log('success, retrieved value of search');
        Invoice.Search(searchNames);
    }
}); 
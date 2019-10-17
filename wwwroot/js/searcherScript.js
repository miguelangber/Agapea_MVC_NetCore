var searchByItem = Array.from(document.getElementsByClassName("dropdown-item"));
var textBox = document.getElementById("textInput");
var searchHandler = {
    searchByTitulo: (ev) => {
        document.getElementById("searchBy").textContent = "Buscar por Título";
    },
    searchByAutor: (ev) => {
        document.getElementById("searchBy").textContent = "Buscar por Autor";

    },
    searchByEditorial: (ev) => {
        document.getElementById("searchBy").textContent = "Buscar por Editorial";

    },
    searchByIsbn: (ev) => {
        document.getElementById("searchBy").textContent = "Buscar por ISBN";

    },
    searcher: (ev) => {
        var searchBy = document.getElementById("searchBy").textContent.substring(11);
        var ruta = "";
        if (searchBy == "título") {
            ruta = window.location.protocol + "//" + window.location.host + "/Home/Buscar/?opcion=Titulo&valor=" + encodeURIComponent(textBox.value);
            window.location.href = ruta;
            console.log("ir a la ruta: " + ruta)
        } else {
            ruta = window.location.protocol + "//" + window.location.host + "/Home/Buscar/?opcion=" + searchBy + "&valor=" + encodeURIComponent(textBox.value);
            window.location.href = ruta;
            console.log("ir a la ruta: " + ruta)
        }
    }

}
searchByItem[0].addEventListener("click", searchHandler.searchByTitulo);
searchByItem[1].addEventListener("click", searchHandler.searchByAutor);
searchByItem[2].addEventListener("click", searchHandler.searchByEditorial);
searchByItem[3].addEventListener("click", searchHandler.searchByIsbn);
document.getElementById("search").addEventListener("click", searchHandler.searcher)
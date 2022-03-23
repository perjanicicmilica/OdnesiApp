import { Prodavnica } from "./Prodavnica.js";
import { Market } from "./Market.js";


var listaProdavnica = [];

fetch("https://localhost:5001/Prodavnica/SveProdavnice")
.then(p=>{
    p.json().then(prodavnice => {
        prodavnice.forEach( prodavnica =>{
            var p = new Prodavnica(prodavnica.idProdavnice, prodavnica.naziv, prodavnica.adresa);
            listaProdavnica.push(p);
        });
        var market = new Market(listaProdavnica,listaKategorija);
        market.crtaj(document.body)

        var listaKategorija = [];
    })
})
   



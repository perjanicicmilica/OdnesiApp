import { Kategorija } from "./Kategorija.js";
import { Proizvodi } from "./Proizvodi.js";
export class Market{
    constructor(listaProdavnica){
        this.listaProdavnica = listaProdavnica;
        this.kont = null;
        this.crtajCheck = 0;
        this.nazivPodavnice = "";
    }

    crtaj(host){
        this.kont = document.createElement("div");
        this.kont.className = "marketKontejner";
        host.appendChild(this.kont);

        let kontForma = document.createElement("div");
        kontForma.className = "forma";
        this.kont.appendChild(kontForma);

        this.crtajFormu(kontForma);
    }

    crtajFormu(host){
        let adminKont;
        let dodajKont;
        let dodajInput;
        let dodajBtn;
        let izmeniKont;
        let izmeniSel;
        let izmeniInput;
        let izmeniBtn;
        let izbrisiKont;
        let izbrisiSel;
        let iz;
        let izbrisiBtn;
        let adminNas;
        let labelPom;
        let labelPom1;
        adminKont = document.createElement("div");
        adminKont.className = "adminKont";
        adminNas = document.createElement("h1");
        adminNas.className = "adminNas"
        adminNas.innerHTML = "Uredite svoje prodavnice";
        adminKont.appendChild(adminNas);
        dodajKont = document.createElement("div");
        dodajKont.className = "dodajKont";
        dodajInput = document.createElement("input");
        dodajInput.type = "text";
        dodajInput.placeholder = "Naziv Prodavnice";
        dodajInput.id = "dodajInp";
        dodajBtn = document.createElement("button");
        dodajBtn.innerHTML = "Dodaj Prodavnicu";
        dodajBtn.onclick=(ev)=>this.dodajProdavnicu();
        dodajKont.appendChild(dodajInput);
        dodajKont.appendChild(dodajBtn);

        izmeniKont = document.createElement("div");
        izmeniKont.className = "izmeniKont";
        labelPom = document.createElement("label");
        izmeniSel = document.createElement("select");
        izmeniSel.className = "izmeniProd";
        this.listaProdavnica.forEach(p=>{
            iz = document.createElement("option");
            iz.innerHTML = p.naziv;
            iz.value = p.id;
            labelPom.value = p.naziv;
            labelPom.id = p.id;
            izmeniSel.appendChild(labelPom);
            izmeniSel.appendChild(iz);
        })
        izmeniInput = document.createElement("input");
        izmeniInput.type = "text";
        izmeniInput.placeholder = "Naziv Prodavnice";
        izmeniInput.id = "izmeniInp";
        izmeniBtn = document.createElement("button");
        izmeniBtn.innerHTML = "Izmeni Prodavnicu";
        izmeniBtn.onclick=(ev)=>this.izmeniProdavnicu();
        izmeniKont.appendChild(izmeniSel);
        izmeniKont.appendChild(izmeniInput);
        izmeniKont.appendChild(izmeniBtn);

        izbrisiKont = document.createElement("div");
        izbrisiKont.className = "izbrisiKont";
        labelPom1 = document.createElement("label");
        izbrisiSel = document.createElement("select");
        izbrisiSel.className = "izbrisiProd";
        this.listaProdavnica.forEach(p=>{
            iz = document.createElement("option");
            iz.innerHTML = p.naziv;
            iz.value = p.id;
            labelPom1.value = p.naziv;
            labelPom1.id = p.id+"iz";
            izbrisiSel.appendChild(labelPom1)
            izbrisiSel.appendChild(iz);
        })
        izbrisiBtn = document.createElement("button");
        izbrisiBtn.innerHTML = "Obrisi Prodavnicu";
        izbrisiBtn.onclick=(ev)=>this.obrisiProdavnicu();
        izbrisiKont.appendChild(izbrisiSel);
        izbrisiKont.appendChild(izbrisiBtn);

        adminKont.appendChild(dodajKont);
        adminKont.appendChild(izmeniKont);
        adminKont.appendChild(izbrisiKont);
        host.appendChild(adminKont);


        let l = document.createElement('h2');
        l.className = "naslov"
        l.innerHTML= "Izaberite jednu prodavnicu";
        host.appendChild(l);

        let se = document.createElement("div");
        se.className = "prodavnice"
        host.appendChild(se);

        let op;
        this.listaProdavnica.forEach(p=>{
            op = document.createElement("button");
            op.className =" prodavniceItem"
            op.innerHTML= p.naziv;
            op.value = p.id;
            op.onclick=(ev)=>this.nadjiKategorije(p.id, host);
            se.appendChild(op);
        })
    }

    nadjiKategorije(id, host){
        let listaKategorija = [];
        fetch("https://localhost:5001/Prodavnica/ProdavnicaPoIdu?id="+id)
        .then(p=>{
            p.json().then(prodavnica =>{
                this.nazivPodavnice = prodavnica[0].naziv
            })
        })
        fetch("https://localhost:5001/Prodavnica/ProdavnicePoKategorijama?index="+id)
        .then(p=>{
            p.json().then(kategorije => {
                kategorije.forEach( kategorija =>{
                    kategorija.kategorijeProdavnice.forEach(kat =>{
                    var k = new Kategorija(kat.idKategorije, kat.naziv);
                    listaKategorija.push(k);
                    })
                });
            let check ="";
            if(this.crtajCheck != 0){
                check = document.getElementById("kategorijeKontainer").remove()
            }
            if(document.getElementById("proizvodiKonteiner")){
                document.getElementById("proizvodiKonteiner").remove()
            }
            check = document.createElement('div');
            check.id = "kategorijeKontainer";
            let le = document.createElement('lable');
            le.innerHTML= "Kategorije: ";
            check.appendChild(le);
            check.check= "check";
            host.appendChild(check);
            let l;
            let cb;
            if(listaKategorija.length === 0){
                alert("Prodavnica se uskoro otvara")
            }
            listaKategorija.forEach(k =>{
                cb = document.createElement("input");
                cb.type ="checkbox";
                cb.value = k.id;
                check.appendChild(cb);
    
                l = document.createElement("label");
                l.innerHTML = k.naziv;
                check.appendChild(l);
            })
            
            let btn = document.createElement("button");
            btn.innerHTML="Nadji proizvode";
            btn.className="nadjiBtn"
            btn.onclick=(ev)=>this.nadjiProizvode(host);
            check.appendChild(btn);
            let btnp = document.createElement("button");
            btnp.innerHTML="Nadji na popustu";
            btnp.className="nadjiBtn"
            btnp.onclick=(ev)=>this.nadjiProizvodeNaPopustu(host,id);
            check.appendChild(btnp);
            this.crtajCheck = this.crtajCheck + 1;
            })
        })  
    }      
       

    nadjiProizvode(host){
        let kategorije = this.kont.querySelectorAll("input[type='checkbox']:checked");
        if(kategorije.length === 0){
            alert("Izaberi Kategoriju");
            return;
        }
        let nizKategorija = "";
        for(let i = 0 ; i < kategorije.length; i++){
            nizKategorija = nizKategorija.concat(kategorije[i].value, "a")
        }

        this.ucitajProizvode(nizKategorija,host)
    }
    ucitajProizvode(nizKategorija,host){
        var proizvodi = [];
        var kategorije = nizKategorija.split("a");
        for ( let i = 0; i < kategorije.length - 1 ; i++){
        fetch("https://localhost:5001/Kategorije/KategorijeProizvoda?id="+kategorije[i])
        .then(p=>{
            p.json().then(proizvod => {
                proizvod.forEach( proizvod =>{
                    proizvod.proizvodiKategorije.forEach(pro =>{
                    var k = new Proizvodi(pro.idProizvoda, pro.naziv,pro.cena,pro.popust);
                    proizvodi.push(k);
                    })
                }); 
                let pro;
                if(document.getElementById("proizvodiKonteiner")){
                    pro = document.getElementById("proizvodiKonteiner").remove()
                }
                pro = document.createElement("div")
                pro.id = "proizvodiKonteiner"
                let naziv;
                naziv = document.createElement("h1");
                naziv.innerHTML = this.nazivPodavnice +" nudi";
                pro.appendChild(naziv);
                proizvodi.forEach( p =>{
                    let proizvodKont = ""
                    proizvodKont = document.createElement("div");
                    proizvodKont.className = "proizvodiItem";
                    let naziv = "";
                    naziv = document.createElement("p");
                    naziv.innerHTML = p.naziv;
                    proizvodKont.appendChild(naziv);
                    let popust = "";
                    popust = document.createElement("p");
                    popust.className="popust";
                    popust.innerHTML = p.popust+"%";
                    proizvodKont.appendChild(popust);
                    let cena = "";
                    cena = document.createElement("p");
                    cena.innerHTML = "cena:  " + p.cena +"rsd";
                    proizvodKont.appendChild(cena);
                    pro.appendChild(proizvodKont);
                })
                host.appendChild(pro);
            });
        });
        }   
    }
    nadjiProizvodeNaPopustu(host,id){
        var listaKategorija = [];
        var proizvodi = []
        fetch("https://localhost:5001/Prodavnica/ProdavnicePoKategorijama?index="+id)
        .then(p=>{
            p.json().then(kategorije => {
                kategorije.forEach( kategorija =>{
                    kategorija.kategorijeProdavnice.forEach(kat =>{
                    var k = new Kategorija(kat.idKategorije, kat.naziv);
                    listaKategorija.push(k);
                    })
            });
            listaKategorija.forEach( kategorija => {
            fetch("https://localhost:5001/Kategorije/KategorijeProizvoda?id="+kategorija.id)
            .then(p=>{
                p.json().then(proizvod => {
                    proizvod.forEach( proizvod =>{
                        proizvod.proizvodiKategorije.forEach(pro =>{
                        var k = new Proizvodi(pro.idProizvoda, pro.naziv,pro.cena,pro.popust);
                        proizvodi.push(k);
                        })
                    });
                let pro;
                if(document.getElementById("proizvodiKonteiner")){
                    pro = document.getElementById("proizvodiKonteiner").remove()
                }
                pro = document.createElement("div")
                pro.id = "proizvodiKonteiner"
                let naziv;
                naziv = document.createElement("h1");
                naziv.innerHTML = this.nazivPodavnice +" na popustu ima:";
                pro.appendChild(naziv);
                proizvodi.forEach(p => {
                    if(p.popust > 0){
                        let proizvodKont = ""
                        proizvodKont = document.createElement("div");
                        proizvodKont.className = "proizvodiItem";
                        let naziv = "";
                        naziv = document.createElement("p");
                        naziv.innerHTML = p.naziv;
                        proizvodKont.appendChild(naziv);
                        let popust = "";
                        popust = document.createElement("p");
                        popust.className="popust";
                        popust.innerHTML = p.popust+"%";
                        proizvodKont.appendChild(popust);
                        let cena = "";
                        cena = document.createElement("p");
                        cena.innerHTML = "cena:  " + p.cena +"rsd";
                        proizvodKont.appendChild(cena);
                        pro.appendChild(proizvodKont);
                    }
                }) 
                host.appendChild(pro);
                })
                });
            });
        });
    });
    }

    dodajProdavnicu(){
        let prodavnica = document.getElementById("dodajInp").value;
        if(prodavnica){
            let prodavnica1 = {
                "naziv":prodavnica,
                "adresa": "adresa"}
            fetch("https://localhost:5001/Prodavnica/Dodaj Prodavnicu",{
                method:"POST",
                headers:{
                    "Content-Type":"application/json"
                },
                body:JSON.stringify(prodavnica1)
            }).then( p => {
                alert("Dodali ste prodavnicu: "+prodavnica);
            })
        }
        else{
            alert("Unesite naziv prodavnice");
        }
    }

    izmeniProdavnicu(){
        let prodavnica = document.getElementById("izmeniInp").value;
        if(prodavnica){
        let prodavnica1 = {
            "naziv":prodavnica,
            "adresa": "adresa"}
        let optionEl = this.kont.querySelector(".izmeniProd");
        var prodavnicaId = optionEl.options[optionEl.selectedIndex].value;
        let stariNaziv = document.getElementById(prodavnicaId).value;
        fetch("https://localhost:5001/Prodavnica/Izmeni Prodavnicu?IdProdavnice="+prodavnicaId,{
                method:"PUT",
                headers:{
                    "Content-Type":"application/json"
                },
                body:JSON.stringify(prodavnica1)
            }).then( b => {
                alert("Izmenili ste prodavnicu: "+ stariNaziv+" u: "+prodavnica);
            })
        }
        else{
            alert("Unesite naziv prodavnice");
        }
    }

    obrisiProdavnicu(){
        let optionEl = this.kont.querySelector(".izbrisiProd");
        var prodavnicaId = optionEl.options[optionEl.selectedIndex].value;
        var starId = prodavnicaId+"iz";
        let stariNaziv = document.getElementById(starId).value;
        fetch("https://localhost:5001/Prodavnica/Izbrisi?id="+prodavnicaId, {
            method: 'DELETE',
            }).then(p=>{
                alert("Izbrisali ste prodavnicu: "+stariNaziv);
            })
    }
}
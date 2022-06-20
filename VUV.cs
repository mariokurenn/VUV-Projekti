﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Xml;
using ConsoleTables;


namespace VUV_Projekti
{
    class VUV
    {
       
        public static string DodajXML() 
        {
            StreamReader sr = new StreamReader(@"C:\Users\Korisnik\Desktop\VUV_Projekti\VUV.xml");
            string xml = "";
            using (sr)
            {
                xml = sr.ReadToEnd();
            }
            return xml;
        }
       
        public static void OcitajPodatkeClanova()
        {
            Console.WriteLine();
            string xml = DodajXML();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            XmlNodeList projekti = xmlObject.SelectNodes("//vuv/projekti/projekt"); 
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"                                            Lista Projekata                                                                           ");
            Console.ResetColor();
            Console.WriteLine("");
            List<Lokacija> listalokacija = listaLokacija();
            ConsoleTable tablicaProjekata = new ConsoleTable("ID", "Naziv", "Nositelj", "Vrijednost", "Status", "Voditelj", "Lokacija");
            foreach (XmlNode projekt in projekti)
            {
                foreach(Lokacija l in listalokacija)
                {
                tablicaProjekata.AddRow(projekt.Attributes["ID"].Value,projekt.Attributes["Naziv"], projekt.Attributes["Nositelj"].Value,projekt.Attributes["Vrijednost"].Value,projekt.Attributes["Status"].Value,projekt.Attributes["Voditelj"].Value,projekt.Attributes["id_lokacije"]);
                    if (projekt.Attributes["ID"].Value == l.id_lokacije)
                    {
                        Console.WriteLine("Test");
                    }
                }

               

            }
            //string[] opcije = { "Natrag"};
            //string prompt = "";
            //Izbornik izlaz = new Izbornik(prompt, opcije);
            //int OdabraniIndex = izlaz.Pokreni();

            //switch (OdabraniIndex)
            //{
            //    case 0:
                
            //    Program.Administracija();

            //        break;
            //}
        }
        //public static void DodajProjekt(string IDP, string _id_lokacije, string id_clana, string Naziv, string Nositelj, string Vrijednost, bool _voditelj)
        //{
        //    string xml = "";
        //    DodajXML(out xml);

        //    XmlDocument xmlObject = new XmlDocument();

        //    // XmlNodeList projekti = xmlObject.SelectNodes("//vuv"); 
        //    // List<Projekt> listaprojekata = new List<Projekt>();
        //    xmlObject.LoadXml(xml);
        //    XmlNode mainNode = xmlObject.SelectNodes("//vuv/projekti");
        //    XmlNode xmlNode = xmlObject.CreateNode(XmlNodeType.Element, "Projekt", null);
        //    XmlAttribute ID = xmlObject.CreateAttribute("ID");
        //    XmlAttribute id_lokacije = xmlObject.CreateAttribute("id_lokacije");
        //    XmlAttribute id_clana = xmlObject.CreateAttribute("id_clana");
        //    XmlAttribute Naziv = xmlObject.CreateAttribute("Naziv");
        //    XmlAttribute Nositelj = xmlObject.CreateAttribute("Nositelj");
        //    XmlAttribute Vrijednost = xmlObject.CreateAttribute("Vrijednost");
        //    XmlAttribute Voditelj = xmlObject.CreateAttribute("Voditelj");
        //    ID.Value = IDP;
        //    id_lokacije.Value = _id_lokacije;
        //    id_clana.Value = id_clana.ToString();
        //    Naziv.Value = Naziv.ToString();
        //    Nositelj.Value = Nositelj.ToString();
        //    Vrijednost.Value = Vrijednost.ToString();
        //    Voditelj.Value = _voditelj.ToString();
        //    XmlNode xmlChildNode = xmlObject.CreateNode(XmlNodeType.Element, "Aktivnost", null);
        //    XmlAttribute id_aktivnostiA = xmlObject.CreateAttribute("id_aktivnosti");
        //    id_aktivnostiA.Value = ();
        //    XmlAttribute id_clanaA = xmlObject.CreateAttribute("id_clana");
        //    id_clanaA.Value = ();
        //    XmlAttribute id_lokacijeA = xmlObject.CreateAttribute("id_lokacije");
        //    XmlAttribute NazivA = xmlObject.CreateAttribute("Naziv");
        //    NazivA.Value = ();
        //    XmlAttribute OpisA = xmlObject.CreateAttribute("Opis");
        //    OpisA.Value = ();
        //    XmlAttribute VrijemeA = xmlObject.CreateAttribute("Vrijeme");
        //    VrijemeA.Value = ();
        //    xmlChildNode.Attributes.Append(id_aktivnostiA);
        //    xmlChildNode.Attributes.Append(id_clanaA);
        //    xmlChildNode.Attributes.Append(id_lokacijeA);
        //    xmlChildNode.Attributes.Append(NazivA);
        //    xmlChildNode.Attributes.Append(OpisA);
        //    xmlChildNode.Attributes.Append(VrijemeA);

        //    xmlNode.Attributes.Append(ID);
        //    xmlNode.Attributes.Append(id_lokacije);
        //    xmlNode.Attributes.Append(id_clana);
        //    xmlNode.Attributes.Append(Naziv);
        //    xmlNode.Attributes.Append(Nositelj);
        //    xmlNode.Attributes.Append(Vrijednost);
        //    xmlNode.Attributes.Append(Voditelj);
        //    xmlNode.AppendChild(xmlChildNode);
        //    mainNode.AppendChild(xmlNode);
        //    xmlObject.Save(xml);

        //}

        //public static void DodajClana(string id_clana, string ime, string prezime, string oib, bool Voditelj)
        //{
        //    string xml = DodajXML(); 

        //    XmlDocument xmlObject = new XmlDocument();
        //    xmlObject.LoadXml(xml);
        //    XmlNode mainNode = xmlObject.SelectSingleNode("//clanoviprojekta");
        //    XmlNode xmlNode = xmlObject.CreateNode(XmlNodeType.Element, "Clan", null);
        //    XmlAttribute _id_clana = xmlObject.CreateAttribute("id_clana");
        //    XmlAttribute _ime = xmlObject.CreateAttribute("ime");
        //    XmlAttribute _prezime = xmlObject.CreateAttribute("prezime");
        //    XmlAttribute _oib = xmlObject.CreateAttribute("Naziv");
        //    XmlAttribute _voditelj = xmlObject.CreateAttribute("Voditelj");
        //    _id_clana.Value = id_clana;
        //    _ime.Value = ime.ToString();
        //    _prezime.Value = prezime.ToString();
        //    _oib.Value = oib.ToString();
        //    _voditelj.Value = Voditelj.ToString();
        //    xmlNode.Attributes.Append(_id_clana);
        //    xmlNode.Attributes.Append(_ime);
        //    xmlNode.Attributes.Append(_prezime);
        //    xmlNode.Attributes.Append(_oib);
        //    xmlNode.Attributes.Append(_voditelj);
        //    mainNode.AppendChild(xmlNode);
        //    xmlObject.Save(@"C:\Users\Korisnik\Desktop\VUV_Projekti\VUV.xml");

        //}

        public static List<Lokacija> listaLokacija()
        {
            string xml = DodajXML();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            XmlNodeList mainNode = xmlObject.SelectNodes("//vuv/lokacije/lokacija");
            List<Lokacija> praznaListaLokacija = new List<Lokacija>();
            foreach (XmlNode node in mainNode)
            {
                praznaListaLokacija.Add(new Lokacija(node.Attributes["id_lokacije"].Value, node.Attributes["adresa"].Value, node.Attributes["postanskibroj"].Value, node.Attributes["grad"].Value,
                node.Attributes["latituda"].Value, node.Attributes["longituda"].Value));
            }
            Console.ReadKey();
            return praznaListaLokacija;

        }

        //public static List<Projekt> listaProjekata()
        //{
        //    string xml = DodajXML();
        //    XmlDocument xmlObject = new XmlDocument();
        //    xmlObject.LoadXml(xml);
        //    XmlNodeList mainNode = xmlObject.SelectNodes("//vuv/projekti/projekt");
        //    List<Projekt> praznaListaProjekata = new List<Projekt>();
        //    foreach(XmlNode node in mainNode)
        //    {
        //        praznaListaProjekata.Add(new Projekt(node.Attributes["ID"].Value,node.Attributes["id_lokacije"]))
        //    }


        //}
    
        public static List<ClanProjekta> listaClanova()
        {

            string xml = DodajXML();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            XmlNodeList mainNode = xmlObject.SelectNodes("//vuv/clanoviprojekta/clan");
            List<ClanProjekta> praznalista = new List<ClanProjekta>();
            foreach (XmlNode node in mainNode)
            {
                praznalista.Add(new ClanProjekta(node.Attributes["id_clana"].Value, node.Attributes["ime"].Value, node.Attributes["prezime"].Value, node.Attributes["oib"].Value,
                Convert.ToBoolean(node.Attributes["voditelj"].Value)));
            }
            Console.ReadKey();
            return praznalista;
            
        }
        public static List<Aktivnost> listaAktivnosti()
        {
            string xml = DodajXML();
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            XmlNodeList mainNode = xmlObject.SelectNodes("//vuv/ListaAktivnosti/aktivnost");
          
            List<Aktivnost> praznalistaAktivnosti = new List<Aktivnost>();
            List<ClanProjekta> clanoviAktivnosti = new List<ClanProjekta>();
            List<Lokacija> listalokacija = listaLokacija();
            foreach (XmlNode node in mainNode)
            {
                clanoviAktivnosti.Clear();
                foreach(XmlNode cp in node.ChildNodes[0])
                {
                    clanoviAktivnosti.Add(new ClanProjekta(cp.Attributes["id_clana"].Value, cp.Attributes["ime"].Value, cp.Attributes["prezime"].Value, cp.Attributes["oib"].Value,
                    Convert.ToBoolean(cp.Attributes["voditelj"].Value)));
                }
                praznalistaAktivnosti.Add(new Aktivnost(node.Attributes["id_aktivnosti"].Value, node.Attributes["Naziv"].Value, node.Attributes["Opis"].Value, node.Attributes["Vrijeme"].Value, node.Attributes["id_lokacije"].Value, new List<ClanProjekta>(clanoviAktivnosti)));
                Console.WriteLine(node.Attributes["id_lokacije"].Value);
            }
       
            ConsoleTable table2 = new ConsoleTable("ID Aktivnosti", "Naziv", "Opis", "Vrijeme", "Lokacija:");
   
            Console.WriteLine("Lista Aktivnosti:");
           
            foreach (Aktivnost a in praznalistaAktivnosti)
            {
                foreach (Lokacija l in listalokacija)
                {
                    Console.WriteLine(a.id_lokacije +"a");
                    Console.WriteLine(l.id_lokacije + "l");
                    if (l.id_lokacije == a.id_lokacije)
                    {
                        table2.AddRow(a.id_aktivnosti, a.Naziv, a.Opis, a.Vrijeme, l.id_lokacije);
                    }
                }
            }
            Console.Write(table2.ToString());
            Console.ReadKey();
            return praznalistaAktivnosti;
           
        }
        public static void NoviProjekt()
        {
            string xml = DodajXML();
            Console.WriteLine("Unesite ID projekta:");
            string ID = Console.ReadLine();
            List<Lokacija> listalokacija = listaLokacija();
            
           ConsoleTable table = new ConsoleTable("ID Lokacije", "Grad", "Postanski broj", "Longituda", "Latituda");
            foreach (Lokacija l in listalokacija)
            {
                table.AddRow(l.id_lokacije, l.Grad, l.Postanskibroj, l.Longituda, l.Latituda);
            }
            Console.WriteLine("Lista Lokacija");

            Console.Write(table.ToString());
            Console.WriteLine("Unesite ID lokacije:");

            string id_lokacije = Console.ReadLine();
            foreach(Lokacija l in listalokacija)
            {
                if (id_lokacije != l.id_lokacije)
                {
                    Console.WriteLine("Takav ID vec postoji.");
                }
                else
                {

                }
            }
            Console.WriteLine("Lista svih članova");
            List<ClanProjekta> listaclanova = listaClanova();
            ConsoleTable table3 = new ConsoleTable("ID Clana", "Ime", "Prezime", "OIB", "Voditelj");
            foreach (ClanProjekta cp in listaclanova)
            {
                table3.AddRow(cp.ID_clana, cp.Ime, cp.Prezime, cp.OIB, cp.Voditelj);
            }
            ConsoleTable table2 = new ConsoleTable("ID Clana", "Ime", "Prezime", "OIB", "Voditelj");
            foreach (ClanProjekta c in listaclanova)
            {
                table2.AddRow(c.ID_clana, c.Ime, c.Prezime, c.OIB, c.Voditelj);

            }
            Console.Write(table.ToString());
            Console.WriteLine("Unesite člana kojeg želite unijeti u projekt:");
            string id_clana = Console.ReadLine();


            //    string postanski_broj = Console.ReadLine();
            //    Console.WriteLine("Unesite ime grada:");
            //    string grad = Console.ReadLine();
            //    Console.WriteLine("Unbesite latitudu grada");
            //    string latituda = Console.ReadLine();
            //    Console.WriteLine("Unesite longitudu grada");
            //    string longituda = Console.ReadLine();
        }


        public static List<Lokacija> DodajLokaciju(List<Lokacija> ListaLokacija)
        {

            do
            {
                try
                {
                    string xml = DodajXML();
                    Console.WriteLine("Unesite ID lokacije:");
                    string id_lokacije = Console.ReadLine();
                    Console.WriteLine("Unesite adresu lokacije:");
                    string adresa_lokacije = Console.ReadLine();
                    Console.WriteLine("Unesite postanski broj lokacije.");
                    string postanski_broj = Console.ReadLine();
                    Console.WriteLine("Unesite ime grada:");
                    string grad = Console.ReadLine();
                    Console.WriteLine("Unbesite latitudu grada");
                    string latituda = Console.ReadLine();
                    Console.WriteLine("Unesite longitudu grada");
                    string longituda = Console.ReadLine();
                    Lokacija l1 = new Lokacija(id_lokacije, adresa_lokacije, postanski_broj, grad, latituda, longituda);
                    XmlDocument xmlObject = new XmlDocument();
                    xmlObject.LoadXml(xml);
                    XmlNode mainNode = xmlObject.SelectSingleNode("//lokacije");
                    XmlNode xmlNode = xmlObject.CreateNode(XmlNodeType.Element, "lokacija", null);
                    XmlAttribute _id_lokacije = xmlObject.CreateAttribute("id_lokacije");
                    XmlAttribute _adresa_ = xmlObject.CreateAttribute("adresa");
                    XmlAttribute _postanskibroj = xmlObject.CreateAttribute("postanskibroj");
                    XmlAttribute _grad = xmlObject.CreateAttribute("grad");
                    XmlAttribute _latituda = xmlObject.CreateAttribute("latituda");
                    XmlAttribute _longituda = xmlObject.CreateAttribute("longituda");
                    _id_lokacije.Value = l1.id_lokacije;
                    _adresa_.Value = l1.Adresa;
                    _postanskibroj.Value = l1.Postanskibroj;
                    _grad.Value = l1.Grad;
                    _latituda.Value = l1.Latituda;
                    _longituda.Value = l1.Longituda;
                    xmlNode.Attributes.Append(_id_lokacije);
                    xmlNode.Attributes.Append(_adresa_);
                    xmlNode.Attributes.Append(_postanskibroj);
                    xmlNode.Attributes.Append(_grad);
                    xmlNode.Attributes.Append(_latituda);
                    xmlNode.Attributes.Append(_longituda);

           
                    foreach (Lokacija l in ListaLokacija)

                        if (l1.id_lokacije == l.id_lokacije)
                        {

                            throw new Exception("Postoji lokacija sa istim ID-em");

                        }

                    mainNode.AppendChild(xmlNode);
                    xmlObject.Save(@"C:\Users\Korisnik\Desktop\VUV_Projekti\VUV.xml");
                    ListaLokacija.Add(l1);
                    return ListaLokacija;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

            while (true);


        }


        public static List<ClanProjekta> DodajClana(List<ClanProjekta> ListaClanova)
        
        {

            string xml = DodajXML();
            Console.WriteLine("Unesite ID clana");
            string ID_clana = Console.ReadLine();
            Console.WriteLine("Unesite Ime clana");
            string Ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime clana");
            string Prezime = Console.ReadLine();
            Console.WriteLine("Unesite OIB clana");
            string oib = Console.ReadLine();

            Console.WriteLine("Ukoliko je clan voditelj unesite true, inace false");
            bool Voditelj = Convert.ToBoolean(Console.ReadLine());

            ClanProjekta cp2 = new ClanProjekta(ID_clana, Ime, Prezime, oib, Voditelj);
   
            XmlDocument xmlObject = new XmlDocument();
            xmlObject.LoadXml(xml);
            XmlNode mainNode = xmlObject.SelectSingleNode("//clanoviprojekta");
            XmlNode xmlNode = xmlObject.CreateNode(XmlNodeType.Element, "clan", null);
            XmlAttribute _id_clana = xmlObject.CreateAttribute("id_clana");
            XmlAttribute _ime = xmlObject.CreateAttribute("ime");
            XmlAttribute _prezime = xmlObject.CreateAttribute("prezime");
            XmlAttribute _oib = xmlObject.CreateAttribute("oib");
            XmlAttribute _voditelj = xmlObject.CreateAttribute("voditelj");
            _id_clana.Value = cp2.ID_clana;
            _ime.Value = cp2.Ime;
            _prezime.Value = cp2.Prezime;
            _oib.Value = cp2.OIB;
            _voditelj.Value = cp2.Voditelj.ToString();
            xmlNode.Attributes.Append(_id_clana);
            xmlNode.Attributes.Append(_ime);
            xmlNode.Attributes.Append(_prezime);
            xmlNode.Attributes.Append(_oib);
            xmlNode.Attributes.Append(_voditelj);
            try
            {
                while (true)
                {
                    foreach (ClanProjekta cp in ListaClanova)
                    {
                        if (cp2.OIB == cp.OIB)
                        {

                            throw new Exception("Postoji clan sa istim OIBOM");

                        }
                        if (cp.ID_clana == cp2.ID_clana)
                        {
                            Console.WriteLine("Postoji clan sa istim ID-om");
                            
                        }
                     
                        break;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); 
            }
            mainNode.AppendChild(xmlNode);
            xmlObject.Save(@"C:\Users\Korisnik\Desktop\VUV_Projekti\VUV.xml");
            ListaClanova.Add(cp2);         
            return ListaClanova;
        }

    }
}

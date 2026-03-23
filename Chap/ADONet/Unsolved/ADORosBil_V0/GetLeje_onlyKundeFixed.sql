select Leje.Id,Kunde.Navn as KundeNavn,BilId,Leje.Dato,Leje.AntalDage
                from Leje
                inner join Kunde on Leje.KundeId=Kunde.Id;
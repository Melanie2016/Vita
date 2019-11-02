/*Ejemplo de como cargar una foto*/
Update Actividad set Foto = 
(SELECT BulkColumn 
/*FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\crossfit.png', Single_Blob) as img)*/ /*Para Vale*/
FROM Openrowset( Bulk 'C:\Proyecto final\tp final posta\Vita\Vita\Content\images\crossfit.png', Single_Blob) as img) /*Angie*/

where Id=8


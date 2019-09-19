use agapeaDB;

bulk insert dbo.Libros from 'C:\Users\34693\Downloads\libros.csv'
with (
  firstrow=3,
  fieldterminator='#',
  rowterminator='\n'
);
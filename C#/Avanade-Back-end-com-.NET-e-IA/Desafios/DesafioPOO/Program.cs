using DesafioPOO.Models;

// TODO: Realizar os testes com as classes Nokia e Iphone
Console.WriteLine("Smartphone Iphone:");
Smartphone iphone = new Iphone("123456789", "iPhone 13", "IMEI123456789", 128);
iphone.Ligar();
iphone.InstalarAplicativo("WhatsApp");

Console.WriteLine("\n");

Console.WriteLine("Smartphone Nokia:");
Smartphone nokia = new Nokia("987654321", "Nokia 7.2", "IMEI987654321", 64);
nokia.ReceberLigacao();
nokia.InstalarAplicativo("Telegram");

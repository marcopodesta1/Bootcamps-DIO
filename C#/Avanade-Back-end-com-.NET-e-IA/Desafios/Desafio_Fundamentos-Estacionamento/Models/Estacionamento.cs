namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // IMPLEMENTADO
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().Trim().ToUpper();
            if (placa.Any())
                veiculos.Add(placa);
            else
                AdicionarVeiculo();
            Console.WriteLine($"Veículo com a placa {placa} cadastrado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            //IMPLEMENTADO
            string placa = Console.ReadLine().Trim().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas;
                string input;
                bool converteu = false;
                do
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    //IMPLEMENTADO
                    input = String.Empty;
                    input = Console.ReadLine().Trim();
                    converteu = int.TryParse(input, out horas);

                }
                while ((!converteu && horas == 0) || input == string.Empty || horas < 0);
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                //IMPLEMENTADO
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal.ToString("F2")}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                veiculos.ForEach(placa => Console.WriteLine(placa));
            }
            else
                Console.WriteLine("Não há veículos estacionados.");
        }
    }
}

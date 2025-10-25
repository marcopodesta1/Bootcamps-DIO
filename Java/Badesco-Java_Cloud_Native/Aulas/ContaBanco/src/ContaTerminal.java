import java.util.Scanner;

public class ContaTerminal {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        System.out.println("Olá. A partir de agora solicitarei algumas informações para prosseguir com a abertura de sua conta!");

        System.out.println("Por favor, digite o seu nome:");
        String nomeCliente = scanner.nextLine();

        System.out.println("Digite o número da sua conta:");
        int numero = scanner.nextInt();

        System.out.println("Digite o número de sua agência:");
        String agencia = scanner.next();

        System.out.println("Qual o valor do depósito?");
        double saldo = scanner.nextDouble();

        scanner.close();

        System.out.println(String.format("Olá %s, obrigado por criar uma conta em nosso banco, sua agência é %s, conta %d e seu saldo de R$ %.2f já está disponível para saque.", nomeCliente, agencia, numero, saldo));

    }
}



public class TiposVariaveis {
    public static void main(String[] args) throws Exception {
        // tipos primitivos
        //Estudem a classe String que representa texto na aplicação

        String meuNome = "MARCO AURELIO ";
        var teste = meuNome + " tem varias letras";

        short numeroCurto = 1;
        int numeroNormal = numeroCurto;
        short numeroCurto2 = (short) numeroNormal;

        int numero = 5;
        numero = 10;

        System.out.println(teste);

        final double VALOR_DE_PI = 3.14;

    }
}

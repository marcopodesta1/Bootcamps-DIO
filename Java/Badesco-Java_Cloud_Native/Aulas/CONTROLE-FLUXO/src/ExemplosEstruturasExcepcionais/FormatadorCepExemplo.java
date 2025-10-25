package ExemplosEstruturasExcepcionais;

public class FormatadorCepExemplo {

    public static void main(String[] args) {
        try {
            String cepFormatado = formatarCep("237650649");
            System.out.println(cepFormatado);
        } catch (CepInvalidoException e) {
            // TODO Auto-generated catch block
            // System.out.println("O cep não corresponde com as regras de negócio.");
        }
    }

    static String formatarCep(String cep) throws CepInvalidoException {
        if (cep.length() != 8)
            throw new CepInvalidoException();
        System.out.println("O cep não corresponde com as regras de negócio.");
        // simulando um cep formatado
        return "23.765-064";
    }
}

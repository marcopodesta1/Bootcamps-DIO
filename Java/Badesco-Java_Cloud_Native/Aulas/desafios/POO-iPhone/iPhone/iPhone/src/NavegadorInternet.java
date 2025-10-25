public class NavegadorInternet implements iPhone {

    public void exibirPagina(String url) {
        System.out.println("Exibindo a página " + url);
    }

    public void adicionarNovaAba() {
        System.out.println("Adicinando nova aba");
    }

    public void atualizarPagina() {
        System.out.println("Atualizando a página");
    }
}

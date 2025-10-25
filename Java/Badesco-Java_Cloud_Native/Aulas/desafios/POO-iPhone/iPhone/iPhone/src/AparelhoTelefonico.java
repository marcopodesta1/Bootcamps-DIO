public class AparelhoTelefonico implements iPhone {

    public void ligar(String numero){
        System.out.println("Ligando para " + numero);
    }

    public void atender(){
        System.out.println("Atendendo o iPhone");
    }

    public void iniciarCorreioVoz(){
        System.out.println("Inniciando o Correio de Voz");
    }
}

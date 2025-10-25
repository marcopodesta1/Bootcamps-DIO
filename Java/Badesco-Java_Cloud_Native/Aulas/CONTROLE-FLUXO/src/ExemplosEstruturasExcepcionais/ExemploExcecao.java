package ExemplosEstruturasExcepcionais;

import java.text.NumberFormat;
import java.text.ParseException;

public class ExemploExcecao {
    public static void main(String[] args) throws ParseException {

        try {
            Number valor = Double.valueOf("a1.75");
            System.out.println(valor);
        } 
        catch (NumberFormatException e) {
            e.printStackTrace();
        }


        try {
            Number valor1 = NumberFormat.getInstance().parse("a1.75");
            System.out.println(valor1);
        } 
        catch (ParseException e) {
            e.printStackTrace();
        }

    }
}
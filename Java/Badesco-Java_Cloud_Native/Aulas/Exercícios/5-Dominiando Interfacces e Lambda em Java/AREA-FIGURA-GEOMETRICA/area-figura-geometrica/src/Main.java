import java.util.Locale;
import java.util.Scanner;

public class Main {

    private static Scanner scanner = new Scanner(System.in).useLocale(Locale.US);

    public static void main(String[] args) {

        int option;
        GeometricForm geometricForm = null;

        while (true) {
            System.out.println("Escolha a forma geométrica para calcular a área!");
            System.out.println("1 - Quadrado");
            System.out.println("2 - Retângulo");
            System.out.println("3 - Círculo");
            System.out.println("4 - Sair do programa");
            option = scanner.nextInt();
            if (option == 1)
                geometricForm = createSquare();
            else if (option == 2)
                geometricForm = createRectangle();
            else if (option == 3)
                geometricForm = createCircle();
            else if (option == 4)
                break;
            else {
                System.out.println("Opção inválida");
                continue;
            }

            System.out.println("O resultado do cálculo da área foi de " + geometricForm.getArea());
        }
        
    }

    private static GeometricForm createSquare() {
        System.out.println("Informe os tamanhos dos lados:");
        var side = scanner.nextDouble();
        return new Square(side);
    }

    private static GeometricForm createRectangle() {
        System.out.println("Informe o tamnhos da base:");
        var base = scanner.nextDouble();
        System.out.println("Informe o tamanho da altura:");
        var height = scanner.nextDouble();
        return new Rectangle(height, base);
    }

    private static GeometricForm createCircle() {
        System.out.println("Informe os tamanhos do raio:");
        var radius = scanner.nextDouble();
        return new Circle(radius);
    }

}

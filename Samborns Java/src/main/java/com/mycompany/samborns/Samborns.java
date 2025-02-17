
package com.mycompany.samborns;
import java.util.List;
import java.util.Scanner;

public class Samborns {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Numeros numeros = new Numeros();
        int cantidad;
        
        do {
            System.out.println("Ingresa una cantidad de números igual o mayor a 10");
            System.out.print("Ingresa la cantidad de números que tendrá la lista: ");
            cantidad = scanner.nextInt();

            if (cantidad < 10) {
                System.out.println("La longitud debe ser igual o mayor a 10. Intenta nuevamente.");
            }
        } while (cantidad < 10);
        
        
        int can = 1;
        
        while (can <= cantidad) {
            System.out.print("Ingrese un número entero entre -15000 y 36500: ");
            if (scanner.hasNextInt()) {
                int numero = scanner.nextInt();
                if (numero >= -15000 && numero <= 36500) {
                    numeros.agregarNumero(numero);
                    can++;
                } else {
                    System.out.println("Error: Número fuera de rango.");
                }
            } else {
                System.out.println("Error: Entrada no válida. Ingrese solo números enteros.");
                scanner.next();
            }
        }

        if (numeros.estaVacio()) {
            System.out.println("No se ingresaron números válidos.");
            return;
        }

        List<Integer> positivos = numeros.getPositivos();
        List<Integer> negativos = numeros.getNegativos();

        System.out.println("Resultados para números positivos:");
        System.out.println("Suma: " + numeros.sumarLista(positivos, 0));
        System.out.println("Promedio: " + numeros.calcularPromedio(positivos));
        System.out.println("Mediana: " + numeros.calcularMediana(positivos));

        System.out.println("\nResultados para números negativos:");
        System.out.println("Suma: " + numeros.sumarLista(negativos, 0));
        System.out.println("Promedio: " + numeros.calcularPromedio(negativos));
        System.out.println("Mediana: " + numeros.calcularMediana(negativos));
    }
}

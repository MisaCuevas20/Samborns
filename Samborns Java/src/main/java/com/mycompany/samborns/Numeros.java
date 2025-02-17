package com.mycompany.samborns;

import java.util.ArrayList;
import java.util.List;

public class Numeros {

    private List<Integer> numeros;

    public Numeros() {
        this.numeros = new ArrayList<>();
    }

    public void agregarNumero(int numero) {
        this.numeros.add(numero);
    }

    public boolean estaVacio() {
        return numeros.isEmpty();
    }

    public List<Integer> getPositivos() {
        List<Integer> positivos = new ArrayList<>();
        for (int num : numeros) {
            if (num >= 0) {
                positivos.add(num);
            }
        }
        return positivos;
    }

    public List<Integer> getNegativos() {
        List<Integer> negativos = new ArrayList<>();
        for (int num : numeros) {
            if (num < 0) {
                negativos.add(num);
            }
        }
        return negativos;
    }

    public double calcularPromedio(List<Integer> lista) {
        if (lista.isEmpty()) {
            return 0;
        }

        return (double) sumarLista(lista, 0) / lista.size();
    }

    //EN ESTA PARTE PUSE LA MEDIANA, EN LAS INSTRUCCIONES DEL EJERCICIO PEDÍA MEDIA Y PROMEDIO
    //PERO HASTA DONDE SÉ ES LO MISMO, ASÍ QUE SUPUSE QUE SE REFERÍAN A LA MEDIA
    public double calcularMediana(List<Integer> lista) {
        if (lista.isEmpty()) {
            return 0;
        }

        List<Integer> ordenada = new ArrayList<>(lista);
        ordenada.sort(Integer::compareTo);

        int medio = ordenada.size() / 2;

        if (ordenada.size() % 2 == 0) {
            return (ordenada.get(medio - 1) + ordenada.get(medio)) / 2.0;
        } else {
            return ordenada.get(medio);
        }
    }

    public int sumarLista(List<Integer> lista, int indice) {
        if (indice >= lista.size()) {
            return 0;
        }
        int acumulado = lista.get(indice) + sumarLista(lista, indice + 1);
        return acumulado;
    }
}

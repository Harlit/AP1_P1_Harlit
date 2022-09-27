using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class RegistrosBLL{
        private Contexto _contexto;

        public RegistrosBLL(Contexto contexto){
            _contexto = contexto;
        }

}
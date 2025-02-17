﻿using Microsoft.AspNetCore.Mvc;
using PWFilmes.API.Context;
using PWFilmes.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PWFilmes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private PWFilmesContext _context;

        public CategoriaController(PWFilmesContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(_context.CategoriaSet.AsEnumerable()); //(lista limitada)
            //return Ok(_context.CategoriaSet.ToList());
        }

        [HttpGet("obter/{codigo}")]
        public IActionResult Obter(int codigo)
        {
            return Ok(_context.CategoriaSet.Find(codigo)); //Find permite encontrar a chave primária do objeto
        }

        [HttpPost ("adicionar")]
        public IActionResult Adicionar (Categoria categoria)
        {
            _context.CategoriaSet.Add(categoria);
            _context.SaveChanges();

            return Created("Created",
                $"Categoria {categoria.Codigo} Adicionada com Sucesso!");
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(Categoria categoria)
        {
            if ( _context.CategoriaSet.Any(p => p.Codigo == categoria.Codigo))
            {
                _context.Attach(categoria); //DIZER QUE O OBJ JÁ EXISTE NO CONTEXT
                _context.CategoriaSet.Update(categoria); //ATUALIZO AD MUDANÇAS DE CATEGORIA
                _context.SaveChanges(); //SALVO AS MUDANÇAS

                return Ok($"Categoria {categoria.Codigo} Atualizada com sucesso"); //SAÍ DO MÉTODO E NÃO EXECUTA A LINHA 54
            } 
            return BadRequest($"Categoria {categoria.Codigo} Não localizada");
        }
        [HttpDelete("Deletar/{codigo}")]
        public IActionResult Excluir(int codigo)
        {
            var categoria = _context.CategoriaSet.Find(codigo); //a categoria se define como categoria
            if (categoria == null)
            {
                return BadRequest($"Categoria {codigo} não localizada");
            }
            _context.CategoriaSet.Remove(categoria);
            _context.SaveChanges();

            return Ok($"Categoria {codigo} removida com sucesso");
        }
    }
}

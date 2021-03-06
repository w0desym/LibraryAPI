using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Services.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;
        private readonly List<string> _categories = new List<string>
        {
            "Biographies & Memoirs",
            "History",
            "Literature & Fiction",
            "Sci-Fi & Fantasy",
            "Science & Math",
            "Best Sellers",
        };

        public LibraryController(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        #region -- Books methods --

        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetBooksAsync()
        {
            var books = await _repositoryService.GetAllAsync<BookModel>();

            if (books != null)
            {
                return Ok(books.OrderBy(x => x.Name));
            }
            else
            {
                return BadRequest(ErrorCode.CouldNotReadItems.ToString());
            }
        }

        [HttpGet]
        [Route("books/categories")]
        public IActionResult GetCategories()
        {
            return Ok(_categories);
        }

        [HttpPost]
        [Route("books")]
        public async Task<IActionResult> AddBookAsync([FromBody]BookModel book)
        {
            try
            {
                if (book == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.ParametersRequired.ToString());
                }

                await _repositoryService.AddAsync(book);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }

            return Ok();
        }

        [HttpDelete]
        [Route("books")]
        public async Task<IActionResult> DeleteBookAsync([FromBody] BookModel book)
        {
            try
            {
                if (book == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.ParametersRequired.ToString());
                }

                await _repositoryService.DeleteAsync(book);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }

            return Ok();
        }

        [HttpPut]
        [Route("books")]
        public async Task<IActionResult> UpdateBookAsync([FromBody] BookModel book)
        {
            try
            {
                if (book == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.ParametersRequired.ToString());
                }

                await _repositoryService.UpdateAsync(book);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }

            return Ok();
        }

        #endregion

        #region -- Readers methods --

        [HttpGet]
        [Route("readers")]
        public async Task<IActionResult> GetReadersAsync()
        {
            var readers = await _repositoryService.GetAllAsync<ReaderModel>();

            if (readers != null)
            {
                return Ok(readers);
            }
            else
            {
                return BadRequest(ErrorCode.CouldNotReadItems.ToString());
            }
        }

        [HttpPost]
        [Route("readers")]
        public async Task<IActionResult> AddReaderAsync([FromBody] ReaderModel reader)
        {
            try
            {
                if (reader == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.ParametersRequired.ToString());
                }

                await _repositoryService.AddAsync(reader);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }

            return Ok();
        }

        [HttpDelete]
        [Route("readers")]
        public async Task<IActionResult> DeleteReaderAsync([FromBody] ReaderModel reader)
        {
            try
            {
                if (reader == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.ParametersRequired.ToString());
                }

                await _repositoryService.DeleteAsync(reader);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }

            return Ok();
        }

        [HttpPut]
        [Route("readers")]
        public async Task<IActionResult> UpdateReaderAsync([FromBody] ReaderModel reader)
        {
            try
            {
                if (reader == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.ParametersRequired.ToString());
                }

                await _repositoryService.UpdateAsync(reader);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }

            return Ok();
        }

        #endregion
    }

    public enum ErrorCode
    {
        ParametersRequired,
        CouldNotReadItems,
        CouldNotCreateItem,
        CouldNotUpdateItem,
        CouldNotDeleteItem
    }
}

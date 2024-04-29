using Microsoft.AspNetCore.Mvc;

namespace modul9_1302220013.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MahasiswaController : ControllerBase
    {
        public static List<string> matkul = new List<string>()
        {
            "PBO", "KPL", "Basdat"
        };
        
        private static List<Mahasiswa> _mahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Rizky Kusuma Nugraha", Nim = "1302220013", course = matkul, year = 20 },
            new Mahasiswa { Nama = "Muhammad Rizqi Fadhillah", Nim = "1302220020", course = matkul, year = 20 },
            new Mahasiswa { Nama = "Reinhard E", Nim = "13022200...", course = matkul, year = 20 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetMahasiswa()
        {
            return _mahasiswa;
        }
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
        {
            if (index < 0 || index >= _mahasiswa.Count)
            {
                return NotFound();
            }

            return _mahasiswa[index];
        }

        [HttpPost]
        public ActionResult PostMahasiswa(Mahasiswa mahasiswa)
        {
            _mahasiswa.Add(mahasiswa);
            return CreatedAtAction(nameof(GetMahasiswaByIndex), new { index = _mahasiswa.Count - 1 }, mahasiswa);
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= _mahasiswa.Count)
            {
                return NotFound();
            }

            _mahasiswa.RemoveAt(index);
            return NoContent();
        }

    }
    public class Mahasiswa
    {
        public string Nama { get; set; }
        public string Nim { get; set; }
        public List<string> course { get; set; }
        public int year { get; set; }

    }
}

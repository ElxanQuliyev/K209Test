
using LibraryAppK209.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryAppK209
{
    public partial class BookForm : Form
    {
        LibraryDBK209Context db = new LibraryDBK209Context();
        Book selectedBook;
        public BookForm()
        {
            InitializeComponent();
        }

        public void LoadComboboxData(string cmdText,ComboBox comboName)
        {
             string conText = Properties.Resources.conString;
            using SqlConnection con = new SqlConnection(conText);
            con.Open();
            using SqlCommand cmd = new SqlCommand(cmdText, con);
            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                comboName.Items.Add(result["Name"].ToString());
            }
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            string cmdText = @"select Name from Authors";
            string cmdText2 = @"select Name from Categories";
            LoadComboboxData(cmdText,cmbAuthors);
            LoadComboboxData(cmdText2,cmbJanr);
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            dtgBooks.DataSource = db.Books.Select(x=>new { 
             x.Id,
            x.Name,
            x.Price,
            CategoryName= x.Category.Name,
            }).ToList();
            dtgBooks.Columns[0].Visible = false;
        }
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string bookName = txtBookName.Text;
            string janrName = cmbJanr.Text;
            decimal price = nmPrice.Value;
            int catID = db.Categories.First(x => x.Name == janrName).Id;
            string authName = cmbAuthors.Text;
            int authId = db.Authors.First(x => x.Name == authName).Id;
            Book newBook=new()
            {
                Name = bookName,
                Price = price,
                CategoryId = catID
            };
            db.Books.Add(newBook);
            db.SaveChanges();

            db.AuthorToBooks.Add(new()
            {
                AuthorId=authId,
                BookId=newBook.Id
            });
            db.SaveChanges();
            LoadDataGrid();
            MessageBox.Show("Book added successfully");
        }

        private void dtgBooks_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowEditDeleteBtn("change");
            int bookId = (int)dtgBooks.Rows[e.RowIndex].Cells[0].Value;
         selectedBook = db.Books.Include(x=>x.Category).First(x=>x.Id==bookId);
            var authorToBook = db.AuthorToBooks.Include(x=>x.Author).FirstOrDefault(x => x.BookId == selectedBook.Id);
            txtBookName.Text = selectedBook.Name;
            nmPrice.Value = (decimal)selectedBook.Price;
            cmbJanr.Text = selectedBook.Category.Name;
            if (authorToBook != null)
            {
                cmbAuthors.Text = authorToBook.Author.Name;
            }
            else
            {
                cmbAuthors.Text = "";
            }
        }

        public void ShowEditDeleteBtn(string txt)
        {
            if (txt=="change")
            {
                btnAddBook.Visible = false;
                btnDelete.Visible = true;
                btnEdit.Visible = true;
            }
            else
            {
                btnAddBook.Visible = true;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int categoryId = db.Categories.First(x => x.Name == cmbJanr.Text).Id;
            int authId = db.Authors.First(x => x.Name == cmbAuthors.Text).Id;

            selectedBook.Name = txtBookName.Text;
            selectedBook.Price = nmPrice.Value;
            selectedBook.CategoryId = categoryId;
            db.AuthorToBooks.RemoveRange(selectedBook.AuthorToBooks);
            AuthorToBook authBook = new()
            {
                AuthorId = authId,
                BookId = selectedBook.Id
            };
            selectedBook.AuthorToBooks.Add(authBook);
            db.Books.Update(selectedBook);
            db.SaveChanges();
            ShowEditDeleteBtn("add");
            LoadDataGrid();
            txtBookName.Text = default;
            nmPrice.Value = default;
            cmbAuthors.Text = default;
            cmbJanr.Text = default;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Are you sure want to delete this book?", "success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (mes == DialogResult.Yes)
            {
                db.AuthorToBooks.RemoveRange(selectedBook.AuthorToBooks);
                db.Books.Remove(selectedBook);
                db.SaveChanges();
                MessageBox.Show("Qaqa sildim","success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LoadDataGrid();

            }

            ShowEditDeleteBtn("add");

        }
    }
}
//SqlConnection con = new SqlConnection(Properties.Resources.conString);
//string conText = "Select * from SelectBookCategory";
//var da = new SqlDataAdapter(conText, con);
//var commandBuilder = new SqlCommandBuilder(da);
//DataSet ds = new DataSet();
//da.Fill(ds);
//dtgBooks.DataSource = ds.Tables[0];

//int authorId=0;
//string conText =Properties.Resources.conString;
//using SqlConnection con2 = new SqlConnection(conText);
//con2.Open();
//string cmdtext2 = $"select Id from Categories where Name=N'{janrName}'";
//using SqlCommand cmd2 = new SqlCommand(cmdtext2, con2);
//var res=cmd2.ExecuteReader();
//while (res.Read())
//{
//    authorId = (int)(res["Id"]);
//}

//using SqlConnection con = new SqlConnection(conText);
//con.Open();
//string commandText = $"INSERT into Books values('{bookName}',{price},{authorId})";
//using SqlCommand com = new SqlCommand(commandText, con);
//com.ExecuteNonQuery();
//MessageBox.Show("Book added successfully");
//con.Close();
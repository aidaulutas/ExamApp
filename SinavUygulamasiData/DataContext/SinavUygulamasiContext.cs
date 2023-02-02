using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SinavUygulamasiData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavUygulamasiData.DataContext
{
    public class SinavUygulamasiContext : IdentityDbContext
    {

        public SinavUygulamasiContext(DbContextOptions<SinavUygulamasiContext> options) : base(options)
        {

        }

        public DbSet<Subject> Subjects { get; set; } 
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public DbSet<Exam> Exams { get; set; }  
        public DbSet<ExamQuestion> ExamQuestions { get; set; }  

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}

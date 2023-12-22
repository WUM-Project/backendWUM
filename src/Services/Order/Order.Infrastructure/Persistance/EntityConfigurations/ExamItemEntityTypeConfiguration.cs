// using Order.Domain.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;


// namespace Order.Infrastructure.Persistance.EntityConfigurations
// {
//     internal sealed class ExamItemEntityTypeConfiguration
//         : IEntityTypeConfiguration<ExamItem>
//     {
//         public void Configure(EntityTypeBuilder<ExamItem> builder)
//         {
//             builder.ToTable("Exams");

//             builder.HasKey(exam => exam.Id);

//             builder.Property(question => question.Id)
//                 .ValueGeneratedOnAdd();

//             builder.Property(exam => exam.Title)
//                 .IsRequired()
//                 .HasMaxLength(100);

//             builder.Property(exam => exam.Description)
//                 .HasMaxLength(1000);

//             builder.Property(exam => exam.DurationTime)
//                 .IsRequired(true);

//             builder.Property(exam => exam.PassingScore)
//                 .IsRequired(true)
//                 .HasPrecision(5, 2);


           
//         }
//     }
// }
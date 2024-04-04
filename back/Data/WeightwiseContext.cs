using Microsoft.EntityFrameworkCore;

namespace back.Models;

public partial class WeightwiseContext : DbContext
{
    public WeightwiseContext()
    {
    }

    public WeightwiseContext(DbContextOptions<WeightwiseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Routine> Routines { get; set; }

    public virtual DbSet<RoutineExercise> RoutineExercises { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }

    public virtual DbSet<WorkoutSet> WorkoutSets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("category", new[] { "strength", "stretching", "plyometrics", "strongman", "powerlifting", "cardio", "olympic weightlifting" })
            .HasPostgresEnum("equipment", new[] { "body only", "machine", "other", "foam roll", "kettlebells", "dumbbell", "cable", "barbell", "bands", "medicine ball", "exercise ball", "e-z curl bar" })
            .HasPostgresEnum("force", new[] { "pull", "push", "static" })
            .HasPostgresEnum("level", new[] { "beginner", "intermediate", "expert" })
            .HasPostgresEnum("mechanic", new[] { "compound", "isolation" })
            .HasPostgresEnum("muscle", new[] { "abdominals", "hamstrings", "adductors", "quadriceps", "biceps", "shoulders", "chest", "middle back", "calves", "glutes", "lower back", "lats", "triceps", "traps", "forearms", "neck", "abductors" });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("exercises_pkey");

            entity.ToTable("exercises");

            entity.HasIndex(e => e.Name, "exercises_name_key").IsUnique();

            entity.Property(e => e.Uuid)
                .ValueGeneratedNever()
                .HasColumnName("uuid");
            entity.Property(e => e.Instructions).HasColumnName("instructions");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Force).HasColumnName("force");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Mechanic).HasColumnName("mechanic");
            entity.Property(e => e.Equipment).HasColumnName("equipment");
            entity.Property(e => e.PrimaryMuscles).HasColumnName("primary_muscles");
            entity.Property(e => e.SecondaryMuscles).HasColumnName("secondary_muscles");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.ImagePath0).HasColumnName("image_path_0");
            entity.Property(e => e.ImagePath1).HasColumnName("image_path_1");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
        });

        modelBuilder.Entity<Routine>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("routines_pkey");

            entity.ToTable("routines");

            entity.Property(e => e.Uuid)
                .ValueGeneratedNever()
                .HasColumnName("uuid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IntervalInDays).HasColumnName("interval_in_days");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserUuid).HasColumnName("user_uuid");

            entity.HasOne(d => d.UserUu).WithMany(p => p.Routines)
                .HasForeignKey(d => d.UserUuid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("routines_user_uuid_fkey");
        });

        modelBuilder.Entity<RoutineExercise>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("routine_exercises_pkey");

            entity.ToTable("routine_exercises");

            entity.Property(e => e.Uuid)
                .ValueGeneratedNever()
                .HasColumnName("uuid");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.ExerciseOrder).HasColumnName("exercise_order");
            entity.Property(e => e.ExerciseUuid).HasColumnName("exercise_uuid");
            entity.Property(e => e.RoutineUuid).HasColumnName("routine_uuid");

            entity.HasOne(d => d.RoutineUu).WithMany(p => p.RoutineExercises)
                .HasForeignKey(d => d.RoutineUuid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("routine_exercises_routine_uuid_fkey");

            entity.HasOne(e => e.ExerciseUu).WithMany(p => p.RoutineExercises)
                .HasForeignKey(d => d.ExerciseUuid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("routine_exercises_exercise_uuid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Uuid)
                .ValueGeneratedNever()
                .HasColumnName("uuid");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("workouts_pkey");

            entity.ToTable("workouts");

            entity.Property(e => e.Uuid)
                .ValueGeneratedNever()
                .HasColumnName("uuid");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.RoutineUuid).HasColumnName("routine_uuid");
            entity.Property(e => e.ScheduledAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduled_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.RoutineUu).WithMany(p => p.Workouts)
                .HasForeignKey(d => d.RoutineUuid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("workouts_routine_uuid_fkey");
        });

        modelBuilder.Entity<WorkoutSet>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("workout_sets_pkey");

            entity.ToTable("workout_sets");

            entity.Property(e => e.Uuid)
                .ValueGeneratedNever()
                .HasColumnName("uuid");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.ExerciseUuid).HasColumnName("exercise_uuid");
            entity.Property(e => e.Reps).HasColumnName("reps");
            entity.Property(e => e.SetOrder).HasColumnName("set_order");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Weight).HasColumnName("weight");
            entity.Property(e => e.WorkoutUuid).HasColumnName("workout_uuid");

            entity.HasOne(d => d.ExerciseUu).WithMany(p => p.WorkoutSets)
                .HasForeignKey(d => d.ExerciseUuid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("workout_sets_exercise_uuid_fkey");

            entity.HasOne(d => d.WorkoutUu).WithMany(p => p.WorkoutSets)
                .HasForeignKey(d => d.WorkoutUuid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("workout_sets_workout_uuid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

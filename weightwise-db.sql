-- Database Setup File
\set ON_ERROR_STOP true
SET statement_timeout = 0;
SET client_encoding = 'UTF8';
SET client_min_messages = warning;

-- Drop Tables
DROP TABLE IF EXISTS users CASCADE;
DROP TABLE IF EXISTS routines CASCADE;
DROP TABLE IF EXISTS routine_exercises CASCADE;
DROP TABLE IF EXISTS exercises CASCADE;
DROP TABLE IF EXISTS workouts CASCADE;
DROP TABLE IF EXISTS workout_sets CASCADE;

-- ENUMS
DROP TYPE IF EXISTS Muscle;
DROP TYPE IF EXISTS Force;
DROP TYPE IF EXISTS Level;
DROP TYPE IF EXISTS Mechanic;
DROP TYPE IF EXISTS Equipment;
DROP TYPE IF EXISTS Category;

CREATE TYPE Muscle AS ENUM (
  'abdominals',
  'hamstrings',
  'adductors',
  'quadriceps',
  'biceps',
  'shoulders',
  'chest',
  'middle back',
  'calves',
  'glutes',
  'lower back',
  'lats',
  'triceps',
  'traps',
  'forearms',
  'neck',
  'abductors'
);

CREATE TYPE Force AS ENUM (
  'pull',
  'push',
  'static'
);

CREATE TYPE Level AS ENUM (
  'beginner',
  'intermediate',
  'expert'
);

CREATE TYPE Mechanic AS ENUM (
  'compound',
  'isolation'
);

CREATE TYPE Equipment AS ENUM (
  'body only',
  'machine',
  'other',
  'foam roll',
  'kettlebells',
  'dumbbell',
  'cable',
  'barbell',
  'bands',
  'medicine ball',
  'exercise ball',
  'e-z curl bar'
);

CREATE TYPE Category AS ENUM (
  'strength',
  'stretching',
  'plyometrics',
  'strongman',
  'powerlifting',
  'cardio',
  'olympic weightlifting'
);

CREATE TABLE "users" (
  "uuid" uuid PRIMARY KEY,
  "username" varchar,
  "email" text,
  "created_at" timestamp,
  "updated_at" timestamp,
  "deleted_at" timestamp
);

CREATE TABLE "routines" (
  "uuid" uuid PRIMARY KEY,
  "user_uuid" uuid,
  "interval_in_days" integer,
  "created_at" timestamp,
  "updated_at" timestamp,
  "deleted_at" timestamp
);

CREATE TABLE "routine_exercises" (
  "uuid" uuid PRIMARY KEY,
  "routine_uuid" uuid,
  "exercise_uuid" uuid,
  "exercise_order" integer,
  "created_at" timestamp,
  "deleted_at" timestamp
);

CREATE TABLE "exercises" (
  "uuid" uuid PRIMARY KEY,
  "name" varchar(100) UNIQUE,
  "force" Force,
  "level" Level,
  "mechanic" Mechanic,
  "equipment" Equipment,
  "primary_muscles" Muscle[],
  "secondary_muscles" Muscle[],
  "instructions" text,
  "category" Category,
  "image_path_0" text,
  "image_path_1" text,
  "created_at" timestamp,
  "deleted_at" timestamp
);

CREATE TABLE "workouts" (
  "uuid" uuid PRIMARY KEY,
  "routine_uuid" uuid,
  "scheduled_at" timestamp,
  "created_at" timestamp,
  "updated_at" timestamp,
  "deleted_at" timestamp
);

CREATE TABLE "workout_sets" (
  "uuid" uuid PRIMARY KEY,
  "workout_uuid" uuid,
  "exercise_uuid" uuid,
  "set_order" integer,
  "reps" integer,
  "weight" numeric,
  "created_at" timestamp,
  "updated_at" timestamp,
  "deleted_at" timestamp
);

ALTER TABLE "routines" ADD FOREIGN KEY ("user_uuid") REFERENCES "users" ("uuid");

ALTER TABLE "routine_exercises" ADD FOREIGN KEY ("routine_uuid") REFERENCES "routines" ("uuid");

ALTER TABLE "routine_exercises" ADD FOREIGN KEY ("exercise_uuid") REFERENCES "exercises" ("uuid");

ALTER TABLE "workouts" ADD FOREIGN KEY ("routine_uuid") REFERENCES "routines" ("uuid");

ALTER TABLE "workout_sets" ADD FOREIGN KEY ("workout_uuid") REFERENCES "workouts" ("uuid");

ALTER TABLE "workout_sets" ADD FOREIGN KEY ("exercise_uuid") REFERENCES "exercises" ("uuid");
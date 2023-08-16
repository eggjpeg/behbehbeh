# C# Query Language Documentation for Project "B³"

## Table of Contents

1. [Introduction](#introduction)
2. [Getting Started](#getting-started)
   - [Prerequisites](#prerequisites)
   - [Installation](#installation)
3. [Syntax and Grammar](#syntax-and-grammar)
   - [Basic Syntax](#basic-syntax)
   - [Data Types](#data-types)
   - [Statements](#statements)
4. [Query Examples](#query-examples)
   - [SELECT Statement](#select-statement)
   - [WHERE Clause](#where-clause)
   - [JOIN Clause](#join-clause)
5. [Advanced Features](#advanced-features)
   - [Functions](#functions)
   - [Aggregations](#aggregations)
   - [Subqueries](#subqueries)
6. [Error Handling](#error-handling)
7. [Conclusion](#conclusion)
8. [References](#references)

## Introduction

The C# Query Language (CQL) for Project "B³" is a domain-specific language designed to emulate SQL-like querying capabilities within C# applications. This documentation outlines the usage, syntax, and features of CQL, implemented using ANTLR (ANother Tool for Language Recognition).

CQL provides developers with a familiar SQL-like syntax for querying and manipulating data, making it easier to interact with databases and other data sources within C# applications.

## Getting Started


### Installation

To start using CQL in your Project "B³" C# project, follow these steps:

1. Create a new C# project or use an existing one.
2. Install the ANTLR runtime for C# using NuGet:
3. Define your CQL grammar using ANTLR syntax in a `.g4` file (e.g., `CqlGrammar.g4`).
4. Use ANTLR to generate C# code from the grammar:
5. Include the generated C# files in your Project "B³" project.
6. Implement the necessary classes to parse and interpret CQL queries using the generated code.

## Syntax and Grammar

### Basic Syntax

CQL for Project "B³" supports a subset of SQL syntax. A basic CQL query follows this structure:

```sql
SELECT column1, column2
FROM table
WHERE condition

Data Types
CQL for Project "B³" supports the following data types:

INT: Integer
STRING: String
DATE: Date
Statements
CQL for Project "B³" supports the following statements:

SELECT: Retrieves data from a table.
WHERE: Filters data based on conditions.
JOIN: Combines data from multiple tables.

Error Handling
CQL for Project "B³" utilizes ANTLR's built-in error handling mechanisms. It provides informative error messages for syntax errors and unexpected input, aiding developers in identifying and resolving issues in their queries.

Conclusion
The C# Query Language (CQL) for Project "B³" provides developers with a powerful tool to query and manipulate data within C# applications using a SQL-like syntax. By leveraging ANTLR, CQL offers a user-friendly and efficient way to interact with databases and other data sources.

References
ANTLR: http://www.antlr.org/
ANTLR4 Runtime for C#: https://www.nuget.org/packages/Antlr4.Runtime/
For more detailed information on ANTLR, refer to its official documentation and resources;
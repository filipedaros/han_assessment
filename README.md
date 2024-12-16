# Hahn assessment - Project structure

API used: https://countries-api-abhishek.vercel.app/countries

## hahn.api
Minimal API project

## hahn.application
This file is used by hanh. API and hanh.worker.jobs. It contains the system's commands and queries.

## hahn.infrastrcture
Used by han.application. Contains the persistence classes and migrations;

## hahn.domain
Domain classes and contracts.

## hahn.worker
Wire up the hangfire and schedule the jobs

## hahn.jobs
Jobs classes used by the worker project.

## hahn.presentation
Vue project used to show the list of imported countries.

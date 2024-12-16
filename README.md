# Hahn assessment - Project structure

## hahn.api
Minimal API project

## hahn.application
Used by han.api and hanh.worker.jobs. Contains the commands e queries of the system.

## hahn.infrastrcture
Used by han.application. Contains the persistence classes and migrations;

## hahn.domain
Domain classes and contracts.

## hahn.worker
Wire up the hangfire and shedules the jobs

## hahn.jobs
Jobs classes used by the worker project.

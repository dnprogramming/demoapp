terraform {
  required_providers {
    google = {
      source  = "hashicorp/google"
      version = "7.14.0"
    }
  }
}

provider "google" {
  credentials = file(var.credentials_file)

  project = var.project_id
  region  = var.region_primary
  zone    = var.az_primary
}

resource "google_compute_network" "vpc_network" {
  name = "network"
}

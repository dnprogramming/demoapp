resource "google_storage_bucket" "limited-expire" {
  name             = "limited-expiring-bucket"
  location         = "US"
  storage_class    = "MULTI_REGIONAL"
  force_destroy    = true
  retention_period = 946771200

  lifecycle_rule {
    condition {
      age = 10958
    }
    action {
      type = "Delete"
    }
  }

  lifecycle_rule {
    condition {
      age = 1
    }
    action {
      type = "AbortIncompleteMultipartUpload"
    }
  }
}

resource "google_storage_bucket" "limited" {
  name          = "storage-bucket"
  location      = "US"
  storage_class = "MULTI_REGIONAL"
  force_destroy = true

  lifecycle_rule {
    condition {
      age = 1
    }
    action {
      type = "AbortIncompleteMultipartUpload"
    }
  }
}
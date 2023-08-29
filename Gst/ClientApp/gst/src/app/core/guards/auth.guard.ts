import { inject } from "@angular/core"
import { UserService } from "../service/user.service"
import { Router } from "@angular/router"

export const AuthGuard = () => {
  const userService = inject(UserService)
  const router = inject(Router)

  if (userService.estalogado()) {
    return true
  }
  router.navigate(['/login'])
  return false
}

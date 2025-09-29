
import { cookies } from "next/headers";

const TOKEN_KEY = "accessToken";

export async function setTokenCookie(token: string) {
  const cookieStore = await cookies();
  cookieStore.set(TOKEN_KEY, token, {
    httpOnly: true,
    secure: true,
    path: "/",
    maxAge: 60 * 60 * 24, 
  });
}

export async function getSessionToken(): Promise<string | undefined> {
  const cookieStore = await cookies();
  return cookieStore.get(TOKEN_KEY)?.value;
}

export async function clearSessionToken() {
  const cookieStore = await cookies();
  cookieStore.delete(TOKEN_KEY);
}
